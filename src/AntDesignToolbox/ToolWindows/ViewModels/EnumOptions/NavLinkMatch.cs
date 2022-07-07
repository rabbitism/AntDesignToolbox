using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum NavLinkMatch
    {
        [StringValue("@NavLinkMatch.Prefix")]
        [Display(Name = "Prefix")]
        [Default]
        Prefix,
        [StringValue("@NavLinkMatch.Prefix")]
        [Display(Name = "All")]
        [Default]
        All
    }
}
