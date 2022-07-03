using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class OptionItemViewModel: BindableBase
    {
        public string DisplayName { get; set; }
        public string Value { get; set; } 
    }
}
