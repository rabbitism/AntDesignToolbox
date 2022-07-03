using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Imaging.Interop;


namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class TreeItemViewModel : BindableBase
    {
        public string ControlName { get; set; }
        public string DefaultMarkup { get; set; }
        public ImageMoniker Moniker { get; set; }

        private ObservableCollection<PropertyItemViewModel> _properties;

        public ObservableCollection<PropertyItemViewModel> Properties { 
            get => _properties;
            set { SetProperty(ref _properties, value); } 
        }

        public TreeItemViewModel()
        {
            Properties = new ObservableCollection<PropertyItemViewModel>();
        }

    }
}