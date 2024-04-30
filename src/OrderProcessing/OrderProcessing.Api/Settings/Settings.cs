using System.Globalization;

namespace OrderProcessing.Api.Settings
{
    public class Settings : ISettings
    {
        private readonly IConfiguration _config;

        public Settings(IConfiguration config)
        {
            ArgumentNullException.ThrowIfNull(config, nameof(config));

            _config = config;
        }

        public int GetIntSetting(string key)
        {
            var setting = GetSettingValue(key);

            try
            {
                return int.Parse(setting, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Setting [{key}] is not an integer", e);
            }
        }

        private string GetSettingValue(string key)
        {
            return _config[key] ?? throw new ArgumentException($"Setting [{key}] does not exist in appsettings.json");
        }
    }
}
