using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using ViMusic.Application.Shared.AudioWriter;
using ViMusic.Application.Shared.ImageWriter;
using ViMusic.Application.Users.Commands.CreateUser;
using ViMusic.Persistence;

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
            // Add MediatR
            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);

            // Add DbContext using SQL Server Provider
            services.AddDbContext<ViMusicDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ViMusicDatabase")));

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

            services.Configure<FormOptions>(options =>
            {
                options.ValueCountLimit = 10; //default 1024
                options.ValueLengthLimit = int.MaxValue; //not recommended value
                options.MultipartBodyLengthLimit = long.MaxValue; //not recommended value
            });

            services.AddControllers();

            services.AddTransient<ImageWriter>();
            services.AddTransient<AudioWriter>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

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
    }
}
