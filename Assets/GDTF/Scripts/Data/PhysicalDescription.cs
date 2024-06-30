using System;
using System.Collections.Generic;
using System.Xml;
using GDTF.Data.PhysicalDescriptions;

namespace GDTF.Data
{
    [Serializable]
    public class PhysicalDescription : IGdtfElement
    {
        #region Node Attributes

        public List<Emitter> emitters;
        public List<Filter> filters;
        public string colorSpace;
        public List<Gamut> gamuts;
        public List<DmxProfile> dmxProfiles;
        public List<ColorRenderingIndexGroup> cris;
        public List<Connector> connectors;
        public Properties properties;

        #endregion

        public void LoadXml(XmlNode node)
        {
            emitters = GdtfSerializer.GetChildNodes<Emitter>(node, "Emitters/Emitter");
            filters = GdtfSerializer.GetChildNodes<Filter>(node, "Filters/Filter");
            colorSpace = GdtfSerializer.GetAttributeValue<string>(node, "ColorSpace");
            gamuts = GdtfSerializer.GetChildNodes<Gamut>(node, "Gamuts/Gamut");
            dmxProfiles = GdtfSerializer.GetChildNodes<DmxProfile>(node, "DMXProfiles/DMXProfile");
            cris = GdtfSerializer.GetChildNodes<ColorRenderingIndexGroup>(node, "CRIs/CRIGroup");
            connectors = GdtfSerializer.GetChildNodes<Connector>(node, "Connectors/Connector");
            properties = GdtfSerializer.GetChildNode<Properties>(node, "Properties");
        }
    }
}
