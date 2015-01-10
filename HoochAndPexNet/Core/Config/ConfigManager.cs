using HoochAndPexNet.Resources.Manager;
using HoochAndPexNet.Resources.Resources;
using System.Linq;
using System.Xml.Linq;
using HoochAndPexNet.Commons.Config.Consts;

namespace HoochAndPexNet.Core.Config
{
    public class ConfigManager : IConfigManager
    {
        private ConfigData _config;
        private IResourceManager _resourceManager;

        public ConfigManager(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
            _config = new ConfigData();
        }

        public void Load(string url)
        {
            var configFile = (ConfigResource)_resourceManager.Get(url, false);
            var xml = configFile.XmlFile;
            LoadScreenConfig(xml);
        }

        public void Save(string url)
        {
            throw new System.NotImplementedException();
        }

        public ConfigData GetConfig()
        {
            return _config;
        }

        private void LoadScreenConfig(XDocument xml)
        {
            var screenElement = xml.Descendants().Where(e => e.Name == ConfigScreenConsts.SCREEN_ROOT_ELEMENT).First();
            _config.ScreenWidth = short.Parse(screenElement.Elements().Where(e => e.Name == ConfigScreenConsts.SCREEN_WIDTH_ELEMENT).First().FirstAttribute.Value);
            _config.ScreenHeight = short.Parse(screenElement.Elements().Where(e => e.Name == ConfigScreenConsts.SCREEN_HEIGHT_ELEMENT).First().FirstAttribute.Value);
        }
    }
}
