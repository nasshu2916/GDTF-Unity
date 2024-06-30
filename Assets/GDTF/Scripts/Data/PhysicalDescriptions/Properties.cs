using System;
using System.Xml;
using JetBrains.Annotations;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class Properties : IGdtfElement
    {
        [CanBeNull] public OperatingTemperature operatingTemperature;

        [CanBeNull] public Weight weight;

        // public PowerConsumption powerConsumption;
        [CanBeNull] public LegHeight legHeight;

        public void LoadXml(XmlNode node)
        {
            operatingTemperature = GdtfSerializer.GetChildNode<OperatingTemperature>(node, "OperatingTemperature");
            weight = GdtfSerializer.GetChildNode<Weight>(node, "Weight");
            // powerConsumption = GdtfSerializer.GetChildNode<PowerConsumption>(node, "PowerConsumption");
            legHeight = GdtfSerializer.GetChildNode<LegHeight>(node, "LegHeight");
        }
    }

    [Serializable]
    public class OperatingTemperature : IGdtfElement
    {
        public float low;
        public float high;

        public void LoadXml(XmlNode node)
        {
            low = GdtfSerializer.GetAttributeValue<float>(node, "Low", 0);
            high = GdtfSerializer.GetAttributeValue<float>(node, "High", 40);
        }
    }

    [Serializable]
    public class Weight : IGdtfElement
    {
        public float value;

        public void LoadXml(XmlNode node)
        {
            value = GdtfSerializer.GetAttributeValue<float>(node, "Value", 0);
        }
    }

    [Serializable]
    public class LegHeight : IGdtfElement
    {
        public float value;

        public void LoadXml(XmlNode node)
        {
            value = GdtfSerializer.GetAttributeValue<float>(node, "Value", 0);
        }
    }
}
