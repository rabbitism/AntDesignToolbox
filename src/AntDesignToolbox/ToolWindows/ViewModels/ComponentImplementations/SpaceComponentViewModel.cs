using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AntDesignToolbox.Commons;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class SpaceComponentViewModel: ComponentViewModel
    {
        public override string GetCompiledComponent()
        {
            XElement element = new XElement(ControlName);

            var splitProperty = Properties.FirstOrDefault(a => a.PropertyName == "Split") as BooleanPropertyViewModel;
            if(splitProperty != null && splitProperty.Value== true)
            {
                var splitElement = new XElement("Split", new XText("---"));
                element.Add(splitElement);
            }
            var childrenProperty = Properties.GetProperty<IntegerOrIteratorPropertyViewModel>("Children");

            var hasChildren = childrenProperty.Iterate || (!childrenProperty.Iterate && childrenProperty.Count > 0);

            if (hasChildren)
            {
                XElement root = element;
                if(splitProperty != null && splitProperty.Value==true)
                {
                    XElement childContent = new XElement("ChildContent");
                    element.Add(childContent);
                    root = childContent;
                }
                if (childrenProperty.Iterate)
                {
                    root.Add(new XText("\n@foreach (var item in collection)\n{\n"));
                    root.Add(new XElement("SpaceItem", "@item"));
                    root.Add(new XText("\n}\n"));
                }
                else
                {
                    for (uint i = 0; i < childrenProperty.Count; i++)
                    {
                        root.Add(new XElement("SpaceItem", $"item {i}"));
                    }
                }
                root.EnsureNotEmpty();
            }

            element.Add(Properties.GetProperty<OptionsPropertyViewModel>("Align")?.ConvertToAttribute());
            element.Add(Properties.GetProperty<OptionsPropertyViewModel>("Direction")?.ConvertToAttribute());
            element.Add(Properties.GetProperty<OptionsPropertyViewModel>("Size")?.ConvertToAttribute());
            element.Add(Properties.GetProperty<BooleanPropertyViewModel>("Wrap")?.ConvertToAttribute());

            return element.ToString() + "\n";
        }
    }
}
