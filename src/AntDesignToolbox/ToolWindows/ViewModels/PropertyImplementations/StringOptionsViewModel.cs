using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    internal class StringOptionsViewModel : PropertyItemViewModel
    {
        public StringOptionItemViewModel DefaultValue { get; set; }

        private ObservableCollection<StringOptionItemViewModel> _options;
        public ObservableCollection<StringOptionItemViewModel> Options
        {
            get { return _options; }
            set { SetProperty(ref _options, value); }
        }

        private StringOptionItemViewModel _selectedValue;

        public StringOptionItemViewModel SelectedValue
        {
            get { return _selectedValue; }
            set { SetProperty(ref _selectedValue, value); }
        }


        public override ICommand ResetCommand { get; set; }

        public override IEnumerable<XAttribute> ConvertToAttributes()
        {
            if (IgnoreOnDefault && SelectedValue == DefaultValue)
            {
                yield break;
            }
            yield return new XAttribute(PropertyName, SelectedValue?.Value ?? string.Empty);
        }

        public override IEnumerable<XNode> ConvertToNodes()
        {
            throw new NotImplementedException();
        }
    }
}
