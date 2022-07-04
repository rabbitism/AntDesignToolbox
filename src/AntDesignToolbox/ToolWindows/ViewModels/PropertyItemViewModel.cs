using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public abstract class PropertyItemViewModel: BindableBase
    {
        #region Properties
        private string _propertyName;
        public string PropertyName
        {
            get { return _propertyName; }
            set { SetProperty(ref _propertyName, value); }
        }

        private PropertyCategory _category;
        public PropertyCategory Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value); }
        }

        public bool IgnoreOnDefault { get; set; }
        #endregion

        #region Commands
        public abstract ICommand ResetCommand { get; set; }
        #endregion
    }


}
