using System;
using System.Collections.Generic;
using System.Xml;

namespace GDTF.Data
{
    [Serializable]
    public class PhysicalDescription : IGdtfElement
    {
        #region Node Attributes

        public List<PhysicalDescriptions.Emitter> emitters;
        public List<PhysicalDescriptions.Filter> filters;
        public string colorSpace;

        // public List<Gamut> _gamuts;
        // public List<DMXProfile> _dMXProfiles;
        // public CRIs _cRIs;
        // public Connectors _connectors;
        // public Properties _properties;

        #endregion

        public void LoadXml(XmlNode node)
        {
            emitters = GdtfSerializer.GetChildNodes<PhysicalDescriptions.Emitter>(node, "Emitters/Emitter");
            filters = GdtfSerializer.GetChildNodes<PhysicalDescriptions.Filter>(node, "Filters/Filter");
            colorSpace = GdtfSerializer.GetAttributeValue<string>(node, "ColorSpace");

            // TODO
        }
    }
}
