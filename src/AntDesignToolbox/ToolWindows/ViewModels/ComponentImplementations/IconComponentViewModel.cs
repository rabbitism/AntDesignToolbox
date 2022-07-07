using AntDesignToolbox.Commons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class IconComponentViewModel: ComponentViewModel
    {
        private ObservableCollection<PropertyItemViewModel> _properties;
        public override ObservableCollection<PropertyItemViewModel> Properties {
            get => _properties;
            set => SetProperty(ref _properties, value);
        }

        public IconComponentViewModel()
        {
            Properties = new ObservableCollection<PropertyItemViewModel>
            {
                new IconTypePropertyViewModel() { PropertyName = "IconProperty" },
                new BooleanPropertyViewModel() { PropertyName = "Spin" },
                new IntegerPropertyViewModel() { PropertyName="Rotate" },
                new StringPropertyViewModel() { PropertyName = "TwoToneColor" }
            };
        }

        public override string GetCompiledComponent()
        {
            XElement element = new XElement(ControlName);
            IconTypePropertyViewModel property = Properties.FirstOrDefault() as IconTypePropertyViewModel;
            if (property != null)
            {
                element.Add(new XAttribute("Theme", property.SelectedTheme?.Value??string.Empty));
                element.Add(new XAttribute("Type", property.SelectedType?.Value??string.Empty));
            }

            element.AddNonNullAttributes(Properties.GetProperty<BooleanPropertyViewModel>("Spin").ConvertToAttributes());
            element.AddNonNullAttributes(Properties.GetProperty<IntegerPropertyViewModel>("Rotate").ConvertToAttributes());
            element.AddNonNullAttributes(Properties.GetProperty<StringPropertyViewModel>("TwoToneColor").ConvertToAttributes());

            return element.ToString()+"\n";
        }
    }
}
