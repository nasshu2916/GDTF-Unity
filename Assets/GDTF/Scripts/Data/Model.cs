using System;
using System.Xml;
using GDTF.Enums;

namespace GDTF.Data
{
    [Serializable]
    public class Model : IGdtfElement
    {
        public string name;
        public float length;
        public float width;
        public float height;
        public PrimitiveType primitiveType;
        public string file;
        public float svgOffsetX;
        public float svgOffsetY;
        public float svgSideOffsetX;
        public float svgSideOffsetY;
        public float svgFrontOffsetX;
        public float svgFrontOffsetY;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            length = GdtfSerializer.GetAttributeValue<float>(node, "Length");
            width = GdtfSerializer.GetAttributeValue<float>(node, "Width");
            height = GdtfSerializer.GetAttributeValue<float>(node, "Height");
            primitiveType = GdtfSerializer.GetAttributeValue<PrimitiveType>(node, "PrimitiveType");
            file = GdtfSerializer.GetAttributeValue<string>(node, "File");
            svgOffsetX = GdtfSerializer.GetAttributeValue<float>(node, "SVGOffsetX");
            svgOffsetY = GdtfSerializer.GetAttributeValue<float>(node, "SVGOffsetY");
            svgSideOffsetX = GdtfSerializer.GetAttributeValue<float>(node, "SVGSideOffsetX");
            svgSideOffsetY = GdtfSerializer.GetAttributeValue<float>(node, "SVGSideOffsetY");
            svgFrontOffsetX = GdtfSerializer.GetAttributeValue<float>(node, "SVGFrontOffsetX");
            svgFrontOffsetY = GdtfSerializer.GetAttributeValue<float>(node, "SVGFrontOffsetY");
        }
    }
}
