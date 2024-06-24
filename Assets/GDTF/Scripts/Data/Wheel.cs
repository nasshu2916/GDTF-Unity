using System;
using System.Collections.Generic;
using System.Xml;

namespace GDTF.Data
{
    [Serializable]
    public class Wheel : IGdtfElement
    {
        #region Node Attributes

        public string name;

        #endregion

        #region Node Children

        public List<Wheels.WheelSlot> slots = new();

        #endregion

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");

            slots = GdtfSerializer.GetChildNodes<Wheels.WheelSlot>(node, "Slot");
        }
    }
}
