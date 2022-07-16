using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Prism.Mvvm;

namespace AntDesignToolbox.Modules.CrudPage.ViewModels
{
	public class ClassViewModel : BindableBase
	{
        public string FilePath { get; set; }
        private string _className;
        public string ClassName { get => _className; set => SetProperty(ref _className, value); }
        public string ClassFullName { get; set; }
        public Document Document { get; set; }
        public INamedTypeSymbol ClassSymbol { get; set; } 

    }
}