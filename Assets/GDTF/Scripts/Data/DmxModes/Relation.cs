using System;

namespace GDTF.Data.DmxModes
{
    [Serializable]
    public class Relation
    {
        public string name;
        public string master;
        public string follower;
        public string type;
    }
}
