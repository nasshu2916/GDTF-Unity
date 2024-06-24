using System;
using System.Xml;

namespace GDTF.Data
{
    [Serializable]
    public class Revision : IGdtfElement
    {
        public string text;
        public DateTime date;
        public uint userID;
        public string modifiedBy;

        public void LoadXml(XmlNode node)
        {
            text = GdtfSerializer.GetAttributeValue<string>(node, "Text");
            date = GdtfSerializer.GetAttributeValue<DateTime>(node, "Date");
            userID = GdtfSerializer.GetAttributeValue<uint>(node, "UserID", 0);
            modifiedBy = GdtfSerializer.GetAttributeValue<string>(node, "ModifiedBy", "");
        }
    }
}
