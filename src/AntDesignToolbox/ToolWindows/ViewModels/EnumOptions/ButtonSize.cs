using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum ButtonSize
    {
        [StringValue("@ButtonSize.Default")]
        [Display(Name = "Default")]
        [Default]
        Default,
        [StringValue("@ButtonSize.Large")]
        [Display(Name = "Large")]
        [Default]
        Large,
        [StringValue("@ButtonSize.Small")]
        [Display(Name = "Small")]
        [Default]
        Small,
    }
}
