using System;
using System.Collections.Generic;
using System.Xml;

namespace GDTF.Data
{
    [Serializable]
    public class AttributeDefinition : IGdtfElement
    {
        #region Node Children

        public List<AttributeDefinitions.ActivationGroup> activationGroups = new();
        public List<AttributeDefinitions.FeatureGroup> featureGroups = new();
        public List<AttributeDefinitions.Attribute> attributes = new();

        #endregion

        public void LoadXml(XmlNode node)
        {
            activationGroups =
                GdtfSerializer.GetChildNodes<AttributeDefinitions.ActivationGroup>(node, "ActivationGroups/ActivationGroup");
            featureGroups =
                GdtfSerializer.GetChildNodes<AttributeDefinitions.FeatureGroup>(node, "FeatureGroups/FeatureGroup");
            attributes = GdtfSerializer.GetChildNodes<AttributeDefinitions.Attribute>(node, "Attributes/Attribute");
        }
    }
}
