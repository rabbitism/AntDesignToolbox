using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class DefaultAttribute : Attribute
    {
        public bool IsDefault { get; } = true;
        // This is a positional argument
        public DefaultAttribute()
        {
            
        }
        
    }
}
