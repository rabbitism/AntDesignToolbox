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
using System.Windows.Input;
using Prism.Commands;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class TreeItemViewModel : BindableBase
    {
        private ComponentViewModel _component;
        public ComponentViewModel Component
        {
            get { return _component; }
            set { SetProperty(ref _component, value); }
        }

        private ObservableCollection<TreeItemViewModel> _children;

        public ObservableCollection<TreeItemViewModel> Children
        {
            get { return _children; }
            set { SetProperty(ref _children, value); }
        }

        public TreeItemViewModel()
        {

        }

        private void OnMouseLeave(object o)
        {
            object obj = o;
            System.Diagnostics.Debug.WriteLine(obj.GetType().Name);

        }



    }
}