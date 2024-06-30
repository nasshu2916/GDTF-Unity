using System;
using System.Xml;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class Gamut : IGdtfElement
    {
        public string name;
        // TODO: List<ColorCIE> に変更する
        public string points;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            points = GdtfSerializer.GetAttributeValue<string>(node, "Points");
        }
    }
}
