using AntDesignToolbox.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class BreadcrumbComponentViewModel: ComponentViewModel
    {
        public override string GetCompiledComponent()
        {
            XElement element = new XElement("Breadcrumb");
            var countProperty = Properties.GetProperty<IntegerPropertyViewModel>("Count");
            if(countProperty!=null && countProperty.Value != null)
            {
                for (int i = 0; i < countProperty.Value; i++)
                {
                    var item = new XElement("BreadcrumbItem", $"Item {i}");
                    item.Add(new XAttribute("Href", string.Empty));
                    element.Add(item);
                }
            }
            var separator = Properties.GetProperty<StringPropertyViewModel>("Separator");
            if(separator!=null && separator.Value != separator.DefaultValue)
            {
                element.Add(new XAttribute("Separator", separator.Value));
            }
            if (element.Elements().Count() == 0)
            {
                element.Add(new XText(string.Empty));
            }
            return element.ToString()+"\n";
        }
    }
}
