using System;
using System.Xml;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class Emitter : IGdtfElement
    {
        public string name;
        public ColorCIE color;
        public float dominantWaveLength;
        public string diodePart;

        public Measurement measurement;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            color = GdtfSerializer.GetAttributeValue<ColorCIE>(node, "Color");
            dominantWaveLength = GdtfSerializer.GetAttributeValue<float>(node, "DominantWaveLength");
            diodePart = GdtfSerializer.GetAttributeValue<string>(node, "DiodePart");

            measurement = GdtfSerializer.GetChildNode<Measurement>(node, "Measurement");
        }
    }
}
