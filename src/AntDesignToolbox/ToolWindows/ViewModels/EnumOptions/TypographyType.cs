using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum TypographyType
    {
        [StringValue("default")]
        [Display(Name = "Default")]
        [Default]
        None,
        [StringValue("@TextElementType.Secondary")]
        [Display(Name = "Secondary")]
        Secondary,
        [StringValue("@TextElementType.Danger")]
        [Display(Name = "Danger")]
        Danger,
        [StringValue("@TextElementType.Warning")]
        [Display(Name = "Warning")]
        Warning,
        [StringValue("success")]
        [Display(Name = "Success")]
        Success,
    }
}
