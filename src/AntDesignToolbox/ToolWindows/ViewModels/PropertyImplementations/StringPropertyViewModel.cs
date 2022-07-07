using System;
using System.Collections.Generic;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;
using System.Xml.Linq;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
	public class StringPropertyViewModel : PropertyItemViewModel
	{
        public string DefaultValue { get; set; } 

        private string _value;
        public string Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public override ICommand ResetCommand { get; set; }

        public StringPropertyViewModel()
        {
            ResetCommand = new DelegateCommand(() => { Value = DefaultValue; });
        }

        public override IEnumerable<XAttribute> ConvertToAttributes()
        {
            if(IgnoreOnDefault && DefaultValue== Value)
            {
                yield break;
            }
            yield return new XAttribute(PropertyName, Value ?? string.Empty);    
        }

        public override IEnumerable<XNode> ConvertToNodes()
        {
            yield return new XElement(PropertyName, Value??string.Empty);
        }
    }
}