using HoochAndPexNet.Resources.Resources;
using System.Collections.Generic;

namespace HoochAndPexNet.Resources.Manager
{
    public class FileResourceManager : IResourceManager
    {
        private Dictionary<string, IResource> _cachedResources;

        public FileResourceManager()
        {
            _cachedResources = new Dictionary<string, IResource>();
        }

        public IResource Get(string url, bool cache)
        {
            if(_cachedResources.ContainsKey(url))
            {
                return _cachedResources[url];
            }
            var resource = LoadResource(url);

            if(cache)
            {
                _cachedResources.Add(url, resource);
            }

            return resource;
        }

        private IResource LoadResource(string url)
        {
            return null;
        }
    }
}
