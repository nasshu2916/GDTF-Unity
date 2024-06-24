using System;
using System.Collections.Generic;

namespace GDTF.Data.DmxModes
{
    [Serializable]
    public class Macro
    {
        public string name;
        public string type;

        public List<MacroDmxStep> macroChannels;
    }

    [Serializable]
    public class MacroDmxStep
    {
        public float duration;

        public List<MacroDmxValue> macroDmxValues;
    }

    [Serializable]
    public class MacroDmxValue
    {
        public int value;
        public string dmxChannel;
    }
}
