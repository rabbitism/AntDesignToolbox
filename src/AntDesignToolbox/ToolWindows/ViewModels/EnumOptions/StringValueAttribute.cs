using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class StringValueAttribute : Attribute
    {
        public string StringValue { get; }

        // This is a positional argument
        public StringValueAttribute(string stringValue)
        {
            StringValue = stringValue;
        }



    }
}
