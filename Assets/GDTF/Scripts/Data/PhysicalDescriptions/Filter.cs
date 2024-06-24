using System;
using System.Xml;
using UnityEngine;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class Filter : IGdtfElement
    {
        public string name;
        public Color color;

        public Measurement measurement;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            color = GdtfSerializer.GetAttributeValue<Color>(node, "Color");

            measurement = GdtfSerializer.GetChildNode<Measurement>(node, "Measurement");
        }
    }
}
