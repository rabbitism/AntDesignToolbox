using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum ButtonType
    {
        [StringValue("@ButtonType.Default")]
        [Display(Name = "Default")]
        [Default]
        Default,
        [StringValue("@ButtonType.Primary")]
        [Display(Name = "Primary")]
        Primary,
        [StringValue("@ButtonType.Dashed")]
        [Display(Name = "Dashed")]
        Dashed,
        [StringValue("@ButtonType.Link")]
        [Display(Name = "Link")]
        Link,
        [StringValue("@ButtonType.Text")]
        [Display(Name = "Text")]
        Text
    }
}
