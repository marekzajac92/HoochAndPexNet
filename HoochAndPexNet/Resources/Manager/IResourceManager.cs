﻿using HoochAndPexNet.Resources.Resources;

namespace HoochAndPexNet.Resources.Manager
{
    public interface IResourceManager
    {
        IResource Get(string url, bool cache);
        void RemoveFromCache(string url);
        void ClearCache();
    }
}
