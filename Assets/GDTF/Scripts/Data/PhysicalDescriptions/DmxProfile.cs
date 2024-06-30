using System;
using System.Collections.Generic;
using System.Xml;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class DmxProfile : IGdtfElement
    {
        public string name;

        public List<Point> points;
        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");

            points = GdtfSerializer.GetChildNodes<Point>(node, "Point");
        }
    }

    [Serializable]
    public class Point : IGdtfElement
    {
        public float dmxPercentage;
        public float cfc0;
        public float cfc1;
        public float cfc2;
        public float cfc3;

        public void LoadXml(XmlNode node)
        {
            dmxPercentage = GdtfSerializer.GetAttributeValue<float>(node, "DMXPercentage");
            cfc0 = GdtfSerializer.GetAttributeValue<float>(node, "CFC0");
            cfc1 = GdtfSerializer.GetAttributeValue<float>(node, "CFC1");
            cfc2 = GdtfSerializer.GetAttributeValue<float>(node, "CFC2");
            cfc3 = GdtfSerializer.GetAttributeValue<float>(node, "CFC3");
        }
    }
}
