
namespace HoochAndPexNet.Core.Config
{
    public interface IConfigManager
    {
        void Load(string url);
        void Save(string url);
        ConfigData GetConfig();
    }
}
