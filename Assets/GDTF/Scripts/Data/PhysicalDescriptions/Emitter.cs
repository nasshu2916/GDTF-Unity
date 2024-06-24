using System;
using System.Xml;
using UnityEngine;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class Emitter : IGdtfElement
    {
        public string name;
        public Color color;
        public float dominantWaveLength;
        public string diodePart;

        public Measurement measurement;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            color = GdtfSerializer.GetAttributeValue<Color>(node, "Color");
            dominantWaveLength = GdtfSerializer.GetAttributeValue<float>(node, "DominantWaveLength");
            diodePart = GdtfSerializer.GetAttributeValue<string>(node, "DiodePart");

            measurement = GdtfSerializer.GetChildNode<Measurement>(node, "Measurement");
        }
    }
}
