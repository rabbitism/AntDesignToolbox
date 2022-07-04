using AntDesignToolbox.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BV = AntDesignToolbox.ToolWindows.ViewModels.BooleanPropertyViewModel;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    internal class LayoutComponentViewModel: ComponentViewModel
    {
        public override string GetCompiledComponent()
        {
            XElement element = new XElement("Layout");
            AddElement(element, "Header");
            AddElement(element, "Sider");
            AddElement(element, "Content");
            AddElement(element, "Footer");
            element.EnsureNotEmpty();
            return element.ToString()+"\n";
        }

        private void AddElement(XElement element, string regionName)
        {
            var property = Properties.FirstOrDefault(a => a.PropertyName == regionName) as BV;
            if (property?.Value == true)
            {
                element.Add(new XElement(regionName, regionName));
            }
        }
    }
}
