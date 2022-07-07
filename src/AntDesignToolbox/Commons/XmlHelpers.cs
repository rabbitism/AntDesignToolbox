using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AntDesignToolbox.Commons
{
    public static class XmlHelper
    {
        public static void AddNonNullAttribute(this XElement element, XAttribute attribute)
        {
            if (attribute is null) return;
            element.Add(attribute);
        }

        public static void AddNonNullAttributes(this XElement element, IEnumerable<XAttribute> attributes)
        {
            if(attributes is null) return;
            foreach(var attribute in attributes)
            {
                if (attribute is null) return;
                element.Add(attribute);
            }
        }

        public static void AddNonNullNodes(this XElement element, IEnumerable<XNode> elements)
        {
            if (elements is null) return;
            foreach(var e in elements)
            {
                if (e is null) return;
                element.Add(e);
            }
        }

        public static void EnsureNotEmpty(this XElement element)
        {
            if (element.Elements().Count() == 0)
            {
                element.Add(new XText("\n\n"));
            }
        }
    }
}
