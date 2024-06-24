using System;
using System.Collections.Generic;
using System.Xml;

namespace GDTF.Data
{
    [Serializable]
    public class Geometry : IGdtfElement
    {
        public string name;
        public string model;
        public string matrix;

        public List<Geometry> geometries = new();

        public void LoadXml(XmlNode node)
        {
            name = GdtfSerializer.GetAttributeValue<string>(node, "Name");
            model = GdtfSerializer.GetAttributeValue<string>(node, "Model");
            matrix = GdtfSerializer.GetAttributeValue<string>(node, "Matrix");

            // FIXME: Geometry が入れ子になって serialize できない可能性があるので修正する
            // geometries = GdtfSerializer.GetChildNodes<Geometry>(node, "Geometry");
            // TODO: 他の子要素を読み込む
        }
    }
}
