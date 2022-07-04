using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Imaging.Interop;
using Prism.Mvvm;
using System.Collections.ObjectModel;


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
            return null;
        }

    }
}
