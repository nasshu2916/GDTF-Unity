using System;
using System.Collections.Generic;
using System.Xml;
using UnityEditor;

namespace GDTF.Data
{
    [Serializable]
    public class FixtureType : IGdtfElement
    {
        public string name;
        public string shortName;
        public string longName;
        public string manufacturer;
        public string description;
        public GUID fixtureTypeID;
        public string thumbnail;
        public int thumbnailOffsetX;
        public int thumbnailOffsetY;
        public GUID refFt;
        public bool canHaveChildren;

        public AttributeDefinition attributeDefinitions = new();
        public List<Wheel> wheels = new();
        public PhysicalDescription physicalDescription = new();
        // public List<Geometry> geometries = new();
        public List<Model> models = new();
        public List<DmxMode> dmxModes = new();
        public List<Revision> revisions = new();
        public List<FixtureTypePreset> fixtureTypePresets = new();
        public List<Protocol> protocols = new();

        public void LoadXml(XmlNode node)
        {
            if (node.Attributes == null) return;

            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            shortName = GdtfSerializer.GetAttributeValue<string>(node, "ShortName");
            longName = GdtfSerializer.GetAttributeValue<string>(node, "LongName");
            manufacturer = GdtfSerializer.GetAttributeValue<string>(node, "Manufacturer");
            description = GdtfSerializer.GetAttributeValue<string>(node, "Description");
            fixtureTypeID = GdtfSerializer.GetAttributeValue<GUID>(node, "FixtureTypeID");
            thumbnail = GdtfSerializer.GetAttributeValue<string>(node, "Thumbnail");
            thumbnailOffsetX = GdtfSerializer.GetAttributeValue<int>(node, "ThumbnailOffsetX");
            thumbnailOffsetY = GdtfSerializer.GetAttributeValue<int>(node, "ThumbnailOffsetY");
            refFt = GdtfSerializer.GetAttributeValue<GUID>(node, "RefFT");
            canHaveChildren = GdtfSerializer.GetAttributeValue<bool>(node, "CanHaveChildren");

            attributeDefinitions = GdtfSerializer.GetChildNode<AttributeDefinition>(node, "AttributeDefinitions");
            wheels = GdtfSerializer.GetChildNodes<Wheel>(node, "Wheels/Wheel");
            physicalDescription = GdtfSerializer.GetChildNode<PhysicalDescription>(node, "PhysicalDescriptions");
            models = GdtfSerializer.GetChildNodes<Model>(node, "Models/Model");
            // TODO: Geometry に対応する
            // geometries = GdtfSerializer.GetChildNodes<Geometry>(node, "Geometries/Geometry");
            dmxModes = GdtfSerializer.GetChildNodes<DmxMode>(node, "DMXModes/DMXMode");
            revisions = GdtfSerializer.GetChildNodes<Revision>(node, "Revisions/Revision");
            fixtureTypePresets = GdtfSerializer.GetChildNodes<FixtureTypePreset>(node, "FTPresets/FTPreset");
            protocols = GdtfSerializer.GetChildNodes<Protocol>(node, "Protocols");
        }
    }
}
