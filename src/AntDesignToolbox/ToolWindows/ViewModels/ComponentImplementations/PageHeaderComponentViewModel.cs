using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AntDesignToolbox.Commons;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class PageHeaderComponentViewModel: ComponentViewModel
    {
        public override string GetCompiledComponent()
        {
            XElement element = new XElement("PageHeader");
            AddElement(element, "Title", "PageHeaderTitle");
            AddElement(element, "Subtitle", "PageHeaderSubtitle");
            AddElement(element, "Content", "PageHeaderContent");
            AddElement(element, "Footer", "PageHeaderFooter");
            AddElement(element, "Tags", "PageHeaderTags");
            AddElement(element, "Extra", "PageHeaderExtra");
            AddElement(element, "Breadcrumb", "PageHeaderBreadcrumb");
            AddElement(element, "Avatar", "PageHeaderAvatar");
            element.EnsureNotEmpty();
            return element.ToString() + "\n";
        }

        private void AddElement(XElement element, string propertyName, string elementName)
        {
            var property = Properties.GetProperty<BooleanPropertyViewModel>(propertyName);
            if (property?.Value==true)
            {
                element.Add(new XElement(elementName, $"\n{propertyName}\n"));
            }
        }
    }
}
