using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Imaging.Interop;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class ComponentViewModel: BindableBase
    {
        public string ControlName { get; set; }
        public string DefaultMarkup { get; set; }
        public ImageMoniker Moniker { get; set; }

        private ObservableCollection<PropertyItemViewModel> _properties;

        public ObservableCollection<PropertyItemViewModel> Properties
        {
            get { return _properties; }
            set { SetProperty(ref _properties, value); }
        }

        public ComponentViewModel()
        {
            Properties = new ObservableCollection<PropertyItemViewModel>();
        }

        public virtual string GetCompiledComponent()
        {
            XElement element = new(ControlName, "");
            foreach(var property in Properties)
            {
                if (property is StringPropertyViewModel sp)
                {
                    if(sp.IgnoreOnDefault && sp.Value== sp.DefaultValue)
                    {
                        continue;
                    }
                    if (sp.PropertyName == "Content" || sp.PropertyName == "ChildContent")
                    {
                        element.Add(new XText(sp.Value));
                    }
                    else
                    {
                        element.Add(new XAttribute(sp.PropertyName, sp.Value));
                    }
                }
                else if (property is BooleanPropertyViewModel bp)
                {
                    if(bp.IgnoreOnDefault && bp.Value== bp.DefaultValue)
                    {
                        continue;
                    }
                    element.Add(new XAttribute(bp.PropertyName, bp.Value.ToString().ToLower()));
                }
                else if (property is OptionsPropertyViewModel op)
                {
                    if (op.IgnoreOnDefault && op.SelectedValue == op.DefaultValue)
                    {
                        continue;
                    }
                    element.Add(new XAttribute(op.PropertyName, op.SelectedValue));
                }
                else if(property is IntegerPropertyViewModel ip)
                {
                    if(ip.IgnoreOnDefault && ip.DefaultValue == ip.Value)
                    {
                        continue;
                    }
                    element.Add(new XElement(ip.PropertyName, ip.Value));
                }
            }

            return element.ToString( SaveOptions.DisableFormatting)+"\n";
        }

    }
}
