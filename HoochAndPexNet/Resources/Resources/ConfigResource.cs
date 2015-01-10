using System;
using System.Xml.Linq;

namespace HoochAndPexNet.Resources.Resources
{
    public class ConfigResource : IResource
    {
        public XDocument XmlFile { get; private set; }

        public void Load(string url)
        {
            XmlFile = XDocument.Load(url);
        }
    }
}
