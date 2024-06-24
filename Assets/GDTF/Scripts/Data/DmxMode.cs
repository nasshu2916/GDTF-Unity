using System;
using System.Collections.Generic;
using System.Xml;
using GDTF.Data.DmxModes;

namespace GDTF.Data
{
    [Serializable]
    public class DmxMode : IGdtfElement
    {
        public string name;
        public string description;
        public string geometry;

        public List<DmxChannel> channels;
        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            description = GdtfSerializer.GetAttributeValue<string>(node, "Description");
            geometry = GdtfSerializer.GetAttributeValue<string>(node, "Geometry");

            channels = GdtfSerializer.GetChildNodes<DmxChannel>(node, "DMXChannels/DMXChannel");
        }
    }
}
