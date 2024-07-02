using System;
using System.Xml;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class ColorSpace : IGdtfElement
    {
        public string name;
        public string mode;
        // [XmlElement("Red")] public ColorCIE _red;
        // [XmlElement("Green")] public ColorCIE _green;
        // [XmlElement("Blue")] public ColorCIE _blue;
        // [XmlElement("WhitePoint")] public ColorCIE _whitePoint;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            mode = GdtfSerializer.GetAttributeValue<string>(node, "Mode");
        }
    }
}
