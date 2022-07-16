using System;
using System.Collections.Generic;
using Prism.Mvvm;

namespace AntDesignToolbox.Modules.CrudPage.ViewModels
{
	public class FolderViewModel : BindableBase
	{
        public string FolderName { get; set; }
        public string FolderPath { get; set; }
    }
}