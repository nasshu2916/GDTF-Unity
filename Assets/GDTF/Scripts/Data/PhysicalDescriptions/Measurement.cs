using System;
using System.Collections.Generic;
using System.Xml;
using GDTF.Enums;

namespace GDTF.Data.PhysicalDescriptions
{
    [Serializable]
    public class Measurement : IGdtfElement
    {
        public float physical;
        public float luminousIntensity;
        public float transmission;
        public InterpolationTo interpolationTo;

        public List<MeasurementPoint> measurementPoints;

        public void LoadXml(XmlNode node)
        {
            physical = GdtfSerializer.GetAttributeValue<float>(node, "Physical");
            luminousIntensity = GdtfSerializer.GetAttributeValue<float>(node, "LuminousIntensity");
            transmission = GdtfSerializer.GetAttributeValue<float>(node, "Transmission");
            interpolationTo = GdtfSerializer.GetAttributeValue<InterpolationTo>(node, "InterpolationTo");

            measurementPoints = GdtfSerializer.GetChildNodes<MeasurementPoint>(node, "MeasurementPoint");
        }
    }

    [Serializable]
    public class MeasurementPoint : IGdtfElement
    {
        public float waveLength;
        public float energy;

        public void LoadXml(XmlNode node)
        {
            waveLength = GdtfSerializer.GetAttributeValue<float>(node, "WaveLength");
            energy = GdtfSerializer.GetAttributeValue<float>(node, "Energy");
        }
    }
}
