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
            var countProperty = Properties.FirstOrDefault(a => a.PropertyName == "Count") as IntegerPropertyViewModel;
            if (countProperty != null)
            {
                int value = countProperty.Value ?? 0;
                XElement root = element;
                if(splitProperty != null && splitProperty.Value==true)
                {
                    XElement childContent = new XElement("ChildContent");
                    element.Add(childContent);
                    root = childContent;
                }
                for(int i =0; i< value; i++)
                {
                    root.Add(new XElement("SpaceItem", "Item"));
                }
            }

            element.Add(Properties.GetProperty<OptionsPropertyViewModel>("Align")?.ConvertToAttribute());
            element.Add(Properties.GetProperty<OptionsPropertyViewModel>("Direction")?.ConvertToAttribute());
            element.Add(Properties.GetProperty<OptionsPropertyViewModel>("Size")?.ConvertToAttribute());
            element.Add(Properties.GetProperty<BooleanPropertyViewModel>("Wrap")?.ConvertToAttribute());

            return element.ToString() + "\n";
        }
    }
}
