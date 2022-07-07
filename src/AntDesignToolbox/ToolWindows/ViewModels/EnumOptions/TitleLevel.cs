using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum TitleLevel
    {
        [StringValue("1")]
        [Display(Name = "h1")]
        [Default]
        H1,
        [StringValue("2")]
        [Display(Name = "h2")]
        H2,
        [StringValue("3")]
        [Display(Name = "h3")]
        H3,
        [StringValue("4")]
        [Display(Name = "h4")]
        H4,
    }
}
