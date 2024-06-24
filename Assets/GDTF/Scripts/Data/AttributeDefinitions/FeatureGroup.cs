using System;
using System.Collections.Generic;
using System.Xml;

namespace GDTF.Data.AttributeDefinitions
{
    [Serializable]
    public class FeatureGroup : IGdtfElement
    {
        public string name;
        public string pretty;

        public List<Feature> features = new();

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            pretty = GdtfSerializer.GetAttributeValue<string>(node, "Pretty");
            features = GdtfSerializer.GetChildNodes<Feature>(node, "Feature");
        }
    }

    [Serializable]
    public class Feature : IGdtfElement
    {
        public string name;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
        }
    }
}
