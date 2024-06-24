using System.Xml;
using UnityEngine;

namespace GDTF.Data
{
    public class GdtfData : ScriptableObject, IGdtfElement
    {
        public string fileName;

        public string dataVersion;

        public FixtureType fixtureType;

        public void LoadXml(XmlNode node)
        {
            dataVersion = GdtfSerializer.GetAttributeValue<string>(node, "DataVersion");

            fixtureType = GdtfSerializer.GetChildNode<FixtureType>(node, "FixtureType");
        }
    }
}
