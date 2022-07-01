using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Editor;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.VisualStudio.Utilities;
using Prism.Mvvm;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
	public class TreeItemViewModel : BindableBase
	{
        public string ControlName { get; set; }
        public string DefaultMarkup { get; set; }

    }
}