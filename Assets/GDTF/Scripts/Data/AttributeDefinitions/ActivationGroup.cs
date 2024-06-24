using System;
using System.Xml;

namespace GDTF.Data.AttributeDefinitions
{
    [Serializable]
    public class ActivationGroup : IGdtfElement
    {
        public string name;

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
        }
    }
}
