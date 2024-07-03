using System;
using System.Xml;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class Filter : IGdtfElement
    {
        public string name;
        public ColorCIE color;

        public Measurement measurement;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            color = GdtfSerializer.GetAttributeValue<ColorCIE>(node, "Color");

            measurement = GdtfSerializer.GetChildNode<Measurement>(node, "Measurement");
        }
    }
}
