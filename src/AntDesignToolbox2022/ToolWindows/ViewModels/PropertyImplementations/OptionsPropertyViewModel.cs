using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class OptionsPropertyViewModel: PropertyItemViewModel
    {
        public string DefaultValue { get; set; }


        private ObservableCollection<string> _options;
        public ObservableCollection<string> Options
        {
            get { return _options; }
            set { SetProperty(ref _options, value); }
        }

        private string _selectedValue;
        public string SelectedValue
        {
            get { return _selectedValue; }
            set { SetProperty(ref _selectedValue, value); }
        }

        public override ICommand ResetCommand { get; set; }

        public OptionsPropertyViewModel()
        {
            ResetCommand = new DelegateCommand(() => { SelectedValue = DefaultValue; });
        }
    }
}
