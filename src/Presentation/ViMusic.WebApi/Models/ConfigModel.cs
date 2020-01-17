using System.Reflection;

namespace ViMusic.WebApi.Models
{
    public class ConfigModel
    {
        public ConfigModel()
        {
            Version = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
        }
        public string ApiHost { get; set; }

        public string GoogleAuthHost { get; set; }
        public string ClientId { get; set; }
        public string Issuer { get; set; }

        public string Version { get; }

        public bool ShowVersion { get; set; }
    }
}
