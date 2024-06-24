using System;
using System.Collections.Generic;
using System.Xml;

namespace GDTF.Data.DmxModes
{
    [Serializable]
    public class DmxChannel : IGdtfElement
    {
        public int dmxBreak;
        public string offset;
        public int defaultVal;
        public string initialFunction;
        public string highlight;
        public string geometry;

        public LogicalChannel logicalChannel;

        public List<Relation> relations;
        public List<Macro> macros;
        public void LoadXml(XmlNode node)
        {
            dmxBreak = GdtfSerializer.GetAttributeValue<int>(node, "DmxBreak");
            offset = GdtfSerializer.GetAttributeValue<string>(node, "Offset");
            defaultVal = GdtfSerializer.GetAttributeValue<int>(node, "DefaultVal");
            initialFunction = GdtfSerializer.GetAttributeValue<string>(node, "InitialFunction");
            highlight = GdtfSerializer.GetAttributeValue<string>(node, "Highlight");
            geometry = GdtfSerializer.GetAttributeValue<string>(node, "Geometry");

            // logicalChannel = GdtfSerializer.GetChildNode<LogicalChannel>(node, "LogicalChannel");
            //
            // relations = GdtfSerializer.GetChildNodes<Relation>(node, "Relations/Relation");
            // macros = GdtfSerializer.GetChildNodes<Macro>(node, "Macros/Macro");
        }
    }


    [Serializable]
    public class LogicalChannel
    {
        public string attribute;
        public string snap;
        public string master;
        public float mibFade;
        public float dmxChangeTimeLimit;

        public List<ChannelFunction> channelFunctions;
    }

    [Serializable]
    public class ChannelFunction
    {
        public string name;
        public string attribute;
        public string originalAttribute;
        public string dmxFrom;
        public int defaultVal;
        public float physicalFrom;
        public float physicalTo;
        public float realFade;
        public float realAcceleration;
        public string wheel;
        public string emitter;
        public string filter;
        public string colorSpace;
        public string modeMaster;
        public string modeFrom;
        public string modeTo;
        public string dmxProfile;
        public float min;
        public float max;
        public string customName;

        public List<ChannelSet> channelSets;
    }

    [Serializable]
    public class ChannelSet
    {
        public string name;
        public string dmxFrom;
        public float physicalFrom;
        public float physicalTo;
        public int wheelSlotIndex;
    }
}
