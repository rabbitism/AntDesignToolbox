using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum MenuTheme
    {
        [StringValue("@MenuTheme.Dark")]
        [Display(Name = "Dark")]
        [Default]
        Dark,
        [StringValue("@MenuTheme.Light")]
        [Display(Name = "Light")]
        Light,
    }
}
