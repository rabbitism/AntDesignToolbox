using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AntDesignToolbox.Commons
{
    public static class XmlHelpers
    {
        public static void AddNonNullAttribute(this XElement element, XAttribute attribute)
        {
            if (attribute is null) return;
            element.Add(attribute);
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
