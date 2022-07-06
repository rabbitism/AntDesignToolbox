using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    /// <summary>
    /// StringOptionItemViewModel 
    /// </summary>
    public class StringOptionItemViewModel : BindableBase
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }

        public StringOptionItemViewModel()
        {

        }

        public StringOptionItemViewModel(string displayName, string value)
        {
            DisplayName = displayName;
            Value = value;
        }

        #region Equals
        public override bool Equals(object obj)
        {
            if (obj is StringOptionItemViewModel vm)
            {
                return vm.DisplayName == DisplayName && vm.Value == Value;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return DisplayName.GetHashCode() ^ Value.GetHashCode();
        }
        public static bool operator ==(StringOptionItemViewModel v1, StringOptionItemViewModel v2)
        {
            return v1.Equals(v2);
        }
        public static bool operator !=(StringOptionItemViewModel v1, StringOptionItemViewModel v2)
        {
            return !v1.Equals(v2);
        } 
        #endregion
    }
}
