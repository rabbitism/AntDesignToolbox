using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Prism.Commands;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class IntegerPropertyViewModel : PropertyItemViewModel
    {
        public int? DefaultValue { get; set; }
        private int? _value;

        public int? Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }

        public override ICommand ResetCommand { get; set; }

        public IntegerPropertyViewModel()
        {
            ResetCommand = new DelegateCommand(() => { Value = DefaultValue; });
        }

        public override IEnumerable<XAttribute> ConvertToAttributes()
        {
            if(IgnoreOnDefault && DefaultValue == Value)
            {
                yield break;
            }
            if(Value == null)
            {
                yield break;
            }
            yield return new XAttribute(PropertyName, Value);
        }

        public override IEnumerable<XNode> ConvertToNodes()
        {
            throw new NotImplementedException();
        }
    }
}
