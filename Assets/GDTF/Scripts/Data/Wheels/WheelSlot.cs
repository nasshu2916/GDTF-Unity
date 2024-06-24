using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace GDTF.Data.Wheels
{
    [Serializable]
    public class WheelSlot : IGdtfElement
    {
        #region Node Attributes

        public string name;
        public Color color;
        public string colorString;
        public string filter;
        public string mediaFileName;

        #endregion

        #region Node Children

        public List<PrismFacet> prismFacets;
        public List<AnimationSystem> animationSystems;

        #endregion

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            color = GdtfSerializer.GetAttributeValue<Color>(node, "Color");
            colorString = GdtfSerializer.GetAttributeValue<string>(node, "ColorString");
            filter = GdtfSerializer.GetAttributeValue<string>(node, "Filter");
            mediaFileName = GdtfSerializer.GetAttributeValue<string>(node, "MediaFileName");

            prismFacets = GdtfSerializer.GetChildNodes<PrismFacet>(node, "PrismFacet");
            animationSystems = GdtfSerializer.GetChildNodes<AnimationSystem>(node, "AnimationSystem");
        }
    }


    [Serializable]
    public class PrismFacet : IGdtfElement
    {
        #region Node Attributes

        public Color color;
        public string rotation;

        #endregion

        public void LoadXml(XmlNode node)
        {
            color = GdtfSerializer.GetAttributeValue<Color>(node, "Color");
            rotation = GdtfSerializer.GetAttributeValue<string>(node, "Rotation");
        }
    }

    [Serializable]
    public class AnimationSystem : IGdtfElement
    {
        #region Node Attributes

        public string p1;
        public string p2;
        public string p3;
        public float radius;

        #endregion

        public void LoadXml(XmlNode node)
        {
            p1 = GdtfSerializer.GetAttributeValue<string>(node, "P1");
            p2 = GdtfSerializer.GetAttributeValue<string>(node, "P2");
            p3 = GdtfSerializer.GetAttributeValue<string>(node, "P3");
            radius = GdtfSerializer.GetAttributeValue<float>(node, "Radius");
        }
    }
}
