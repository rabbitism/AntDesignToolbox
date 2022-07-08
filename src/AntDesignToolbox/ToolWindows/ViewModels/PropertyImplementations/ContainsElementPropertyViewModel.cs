using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Prism.Mvvm;
using Prism.Commands;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    internal class ContainsElementPropertyViewModel : PropertyItemViewModel
    {
        #region Properties
        public override bool IsAttribute { get; set; } = false;
        private bool? _value;
        public bool? Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
        public bool? DefaultValue { get; set; } = false;


        #endregion
        public override ICommand ResetCommand { get; set; }

        public ContainsElementPropertyViewModel()
        {
            ResetCommand = new DelegateCommand(() => { Value = DefaultValue; });
            Value = false;
        }

        public override IEnumerable<XAttribute> ConvertToAttributes()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<XNode> ConvertToNodes()
        {
            if(Value == true)
            {
                yield return new XElement(PropertyName, PropertyName);
            }
        }
    }
}
