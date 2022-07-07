using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum Direction
    {
        [StringValue("@DirectionVHType.Horizontal")]
        [Display(Name = "Horizontal")]
        Horizontal,
        [StringValue("@DirectionVHType.Vertical")]
        [Display(Name = "Vertical")]
        [Default]
        Vertical,
    }
}
