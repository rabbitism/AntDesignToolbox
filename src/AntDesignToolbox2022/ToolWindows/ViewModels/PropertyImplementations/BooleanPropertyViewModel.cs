using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class BooleanPropertyViewModel : PropertyItemViewModel
    {
        public bool? DefaultValue { get; set; }

        private bool? _value;
        public bool? Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public override ICommand ResetCommand { get; set; }

        public BooleanPropertyViewModel()
        {
            ResetCommand = new DelegateCommand(() => { Value = DefaultValue; });
        }
    }
}
