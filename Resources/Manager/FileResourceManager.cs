using HoochAndPexNet.Resources.Resources;
using System;
using System.Linq;
using System.Collections.Generic;

namespace HoochAndPexNet.Resources.Manager
{
    public class FileResourceManager : IResourceManager
    {
        #region private_variables

        private Dictionary<string, IResource> _cachedResources;
        private Dictionary<string, Type> _knownResourceTypes;

        #endregion

        #region public_methods

        public FileResourceManager()
        {
            _cachedResources = new Dictionary<string, IResource>();
            Initialize();
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

        public void RemoveFromCache(string url)
        {
            if(_cachedResources.ContainsKey(url))
            {
                _cachedResources.Remove(url);
            }
        }

        public void ClearCache()
        {
            _cachedResources.Clear();
        }

        #endregion

        #region private_methods

        private IResource LoadResource(string url)
        {
            var extension = ExtractExtension(url);
            if(!_knownResourceTypes.ContainsKey(extension))
            {
                throw new ArgumentException(string.Format("Invalid extension \"{0}\" in URL: {1}", extension, url));
            }

            var resource = CreateObjectFromExtension(extension);
            resource.Load(url);

            return resource;
        }

        private void Initialize()
        {
            _knownResourceTypes = new Dictionary<string, Type>();
            _knownResourceTypes.Add("ogg", typeof(MusicResource));
            _knownResourceTypes.Add("wav", typeof(SoundResource));
            _knownResourceTypes.Add("png", typeof(ImageResource));
            _knownResourceTypes.Add("xml", typeof(ConfigResource));
        }

        private string ExtractExtension(string url)
        {
            var extension = url.Split('.').Last();
            return extension;
        }

        private IResource CreateObjectFromExtension(string extension)
        {
            var resource = (IResource)Activator.CreateInstance(_knownResourceTypes[extension]);
            return resource;
        }

        #endregion
    }
}
