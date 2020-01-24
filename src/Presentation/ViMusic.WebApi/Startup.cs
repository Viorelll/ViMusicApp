using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Threading.Tasks;
using ViMusic.Application.Shared.AudioWriter;
using ViMusic.Application.Shared.ImageWriter;
using ViMusic.Application.Users.Commands.CreateUser;
using ViMusic.Persistence;
using ViMusic.WebApi.Models;

namespace ViMusic.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext using SQL Server Provider
            services.AddDbContext<ViMusicDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ViMusicDatabase")));

            UseAuthentication(services);

            // Add MediatR
            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);

            // Add Spa configuration
            services.Configure<ConfigModel>(Configuration.GetSection("SpaConfig"));

            // Add services
            services.AddTransient<ImageWriter>();
            services.AddTransient<AudioWriter>();

            // Register the Swagger services
            services.AddOpenApiDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "ViMusic API";
                    document.Info.Description = "ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                };
            });

            services.AddCors(options =>
            {
                var allowedHostsSection = Configuration.GetSection("AllowedHosts");
                var allowedHosts = allowedHostsSection.Get<string[]>();

                options.AddPolicy("CorsPolicy",
                builder => builder
                   .WithOrigins(allowedHosts)
                   .AllowAnyMethod()
                   .AllowAnyHeader());
            });

            // Authorize all actions
            services.AddMvc(
                config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                                     .RequireAuthenticatedUser()
                                     .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();

            app.UseSwaggerUi3(options => {
                options.Path = "/api";
                options.ServerUrl = "13.94.145.247";
            });
        }

        private void UseAuthentication(IServiceCollection services)
        {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = Configuration.GetSection("SpaConfig").GetValue<string>("Issuer"); 
                    options.Audience = Configuration.GetSection("SpaConfig").GetValue<string>("ClientId");

                    options.RequireHttpsMetadata = false;

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Headers["access_token"];

                            if (!string.IsNullOrEmpty(accessToken))
                            {
                                // Read the token out of the header
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
        }
    }
}
