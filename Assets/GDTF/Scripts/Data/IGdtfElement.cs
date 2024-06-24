using System.Xml;

namespace GDTF.Data
{
    public interface IGdtfElement
    {
        public void LoadXml(XmlNode node);
    }
}
