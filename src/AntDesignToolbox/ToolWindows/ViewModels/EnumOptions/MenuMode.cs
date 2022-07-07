using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum MenuMode
    {
        [StringValue("@MenuMode.Vertical")]
        [Display(Name = "Vertical")]
        [Default]
        Vertical,
        [StringValue("@MenuMode.Horizontal")]
        [Display(Name = "Horizontal")]
        Horizontal,
        [StringValue("@MenuMode.Inline")]
        [Display(Name = "Inline")]
        Inline,
    }
}
