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
    }
}
