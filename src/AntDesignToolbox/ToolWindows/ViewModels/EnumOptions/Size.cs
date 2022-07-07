using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum Size
    {
        [StringValue("@AntSizeLDSType.Default")]
        [Display(Name = "Default")]
        [Default]
        Default,
        [StringValue("@AntSizeLDSType.Large")]
        [Display(Name = "Large")]
        Large,
        [StringValue("@AntSizeLDSType.Small")]
        [Display(Name = "Small")]
        Small,
    }
}
