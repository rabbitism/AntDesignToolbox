using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Prism.Mvvm;

namespace AntDesignToolbox.Modules.CrudPage.ViewModels
{
	public class PropertyViewModel : BindableBase
	{
        private string _propertyName;
        public string PropertyName { get => _propertyName; set => SetProperty(ref _propertyName, value); }

        private bool _selected;
        public bool Selected { get => _selected; set => SetProperty(ref _selected, value); }

        private string _propertyType;
        public string PropertyType { get => _propertyType; set => SetProperty(ref _propertyType, value); } 

        public IPropertySymbol PropertySymbol { get; set; }
    }
}