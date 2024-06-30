using System;
using System.Collections.Generic;
using System.Xml;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class ColorRenderingIndexGroup : IGdtfElement
    {
        public float colorTemperature;
        public List<ColorRenderingIndex> colorRenderingIndexes;

        public void LoadXml(XmlNode node)
        {
            colorTemperature = GdtfSerializer.GetAttributeValue<float>(node, "ColorTemperature");
            colorRenderingIndexes = GdtfSerializer.GetChildNodes<ColorRenderingIndex>(node, "CRI");
        }
    }

    [Serializable]
    public class ColorRenderingIndex : IGdtfElement
    {
        public string ces;
        public uint colorRenderingIndex;

        public void LoadXml(XmlNode node)
        {
            ces = GdtfSerializer.GetAttributeValue<string>(node, "CES");
            colorRenderingIndex = GdtfSerializer.GetAttributeValue<uint>(node, "ColorRenderingIndex");
        }
    }
}
