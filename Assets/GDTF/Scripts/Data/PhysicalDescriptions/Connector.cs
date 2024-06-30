using System;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class Connector : IGdtfElement
    {
        public string name;
        public string type;
        public uint dmxBrake;
        public int gender;
        public float length;

        public void LoadXml(System.Xml.XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            type = GdtfSerializer.GetAttributeValue<string>(node, "Type");
            dmxBrake = GdtfSerializer.GetAttributeValue<uint>(node, "DMXBrake");
            gender = GdtfSerializer.GetAttributeValue<int>(node, "Gender");
            length = GdtfSerializer.GetAttributeValue<float>(node, "Length");
        }
    }
}
