using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Docker.Webhook.Deploy.Settings
{
    public static class SettingsExtensions
    {
        private const string CONFIG_DIR = "Configs";
        public static T GetSettings<T>() where T : new()
        {
            var fileName = $"{typeof(T).Name.Replace("Settings", string.Empty)}.json";
            var filePath = Path.Combine(CONFIG_DIR, fileName);
            var settingJson = File.ReadAllText(filePath);
            var configurationValue = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(settingJson);
            
            return configurationValue;
        }
    }
}
