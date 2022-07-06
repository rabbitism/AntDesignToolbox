using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Imaging.Interop;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Windows.Input;
using Prism.Commands;
using AntDesignToolbox.Commons;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class ComponentViewModel: BindableBase
    {
        public string ControlName { get; set; }
        public string ControlDisplayName { get; set; }
        public string DefaultMarkup { get; set; }
        public ImageMoniker Moniker { get; set; }
        public bool AlwaysDefault { get; set; }

        private ObservableCollection<PropertyItemViewModel> _properties;

        public virtual ObservableCollection<PropertyItemViewModel> Properties
        {
            get { return _properties; }
            set { SetProperty(ref _properties, value); }
        }

        public ICommand ResetAllCommand { get; set; }

        public ComponentViewModel()
        {
            Properties = new ObservableCollection<PropertyItemViewModel>();
            ResetAllCommand = new DelegateCommand(ResetAll);
        }

        private void ResetAll()
        {
            foreach(var property in Properties)
            {
                property.ResetCommand.Execute(null);
            }
        }

        public virtual string GetCompiledComponent()
        {
            if (AlwaysDefault)
            {
                return DefaultMarkup;
            }
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
                else
                {
                    element.AddNonNullAttribute(property.ConvertToAttribute());
                }
            }

            return element.ToString( SaveOptions.DisableFormatting)+"\n";
        }

    }
}
