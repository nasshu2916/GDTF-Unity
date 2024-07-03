using System;
using System.Xml;
using GDTF.Enums;

namespace GDTF.Data.AttributeDefinitions
{
    [Serializable]
    public class Attribute : IGdtfElement
    {
        public string name;
        public string pretty;
        public string activationGroup;
        public string feature;
        public string mainAttribute;
        public PhysicalUnit physicalUnit;
        public ColorCIE color;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            pretty = GdtfSerializer.GetAttributeValue<string>(node, "Pretty");
            activationGroup = GdtfSerializer.GetAttributeValue<string>(node, "ActivationGroup");
            feature = GdtfSerializer.GetAttributeValue<string>(node, "Feature");
            mainAttribute = GdtfSerializer.GetAttributeValue<string>(node, "MainAttribute");
            physicalUnit = GdtfSerializer.GetAttributeValue<PhysicalUnit>(node, "PhysicalUnit");
            color = GdtfSerializer.GetAttributeValue<ColorCIE>(node, "Color");
        }
    }
}
