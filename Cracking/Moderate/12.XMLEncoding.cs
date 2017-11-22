using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cracking.Moderate
{
    /// <summary>
    /// 16.12 XML Encoding: Since XML is very verbose, you are given a way of encoding it where each tag gets
    /// mapped to a pre-defined integer value.The language/grammar is as follows:
    /// Element --> Tag Attributes END Children END
    /// Attribute --> Tag Value
    /// END --> 0
    /// Tag --> some predefined mapping to int
    /// Value --> string value
    /// For example, the following XML might be converted into the compressed string below(assuming a
    /// mapping of family -> 1, person ->2, firstName -> 3, lastName -> 4, state -> 5).
    /// <family lastName = "McDowell" state="CA">
    /// <person firstName = "Gayle" > Some Message</ person>
    /// </ family>
    /// Becomes: 1 4 McDowell 5 CA 0 2 3 Gayle 0 Some Message 0 0
    /// Write code to print the encoded version of an XML element(passed in Element and Attribute objects).
    /// </summary>
    class XMLEncoding
    {
        public void Test()
        {
            XmlDocument doc = new XmlDocument();
            string xml = "<family lastName = \"McDowell\" state=\"CA\"><person firstName = \"Gayle\" >Some Message</person></family>";
            doc.LoadXml(xml);
            ContructMap();
            string encodedXml = EncodeXmlToString(doc.FirstChild);

        }        

        Dictionary<string, int> map = new Dictionary<string, int>();

        private string EncodeXmlToString(XmlNode node)
        {
            StringBuilder sb = new StringBuilder();
            EncodeXmlToString(node, sb);
            return sb.ToString();
        }

        private void EncodeXmlToString(XmlNode node, StringBuilder sb)
        {
            //Encode the tag name
            Encode(GetNumericValueFromMap(node.Name), sb);
            //Encode all attributes
            foreach(XmlAttribute attr in node.Attributes)
            {
                Encode(GetNumericValueFromMap(attr.Name), sb);
                Encode(attr.Value, sb);
            }
            //Add attributes endoing code: 0
            Encode("0", sb);

            //Encode child nodes or node value if there is no children.
            //Node that has text like <Node>text content</Node>, will have children nodes so we check if it is only one child and its type is Text
            if (node.ChildNodes.Count == 1 && node.ChildNodes[0].NodeType == XmlNodeType.Text)
            {
                Encode(node.InnerText, sb);
            }
            else
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    EncodeXmlToString(child, sb);
                }
            }

            //Add node endoing code: 0
            Encode("0", sb);

        }

        private void Encode(string val, StringBuilder sb)
        {
            sb.Append(val);
            sb.Append(" ");
        }


        private void ContructMap()
        {
            map.Add("family", 1);
            map.Add("person", 2);
            map.Add("firstName", 3);
            map.Add("lastName", 4);
            map.Add("state", 5);
        }
        private string GetNumericValueFromMap(string tag)
        {
            if (map.ContainsKey(tag))
                return map[tag].ToString();
            else
                return string.Empty;
        }
    }
}
