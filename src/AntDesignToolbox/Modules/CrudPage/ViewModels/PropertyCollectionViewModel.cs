using System;
using System.Collections.Generic;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using Prism.Commands;

namespace AntDesignToolbox.Modules.CrudPage.ViewModels
{
	public class PropertyCollectionViewModel : BindableBase
	{
        private string _className;
        public string ClassName { get => _className; set => SetProperty(ref _className, value); }

        private ObservableCollection<PropertyViewModel> _properties;
        public ObservableCollection<PropertyViewModel> Properties { get => _properties; set => SetProperty(ref _properties, value); }

        private bool _isBaseClass;
        public bool IsBaseClass { get => _isBaseClass; set => SetProperty(ref _isBaseClass, value); } 

        public PropertyCollectionViewModel()
        {
            Properties = new ObservableCollection<PropertyViewModel>();
        }
    }
}