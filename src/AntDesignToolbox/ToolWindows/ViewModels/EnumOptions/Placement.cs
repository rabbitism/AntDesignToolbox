using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntDesignToolbox.ToolWindows.ViewModels.EnumOptions
{
    internal enum Placement
    {
        [StringValue("@Placement.TopLeft")]
        [Default]
        TopLeft,
        [StringValue("@Placement.TopCenter")]
        TopCenter,
        [StringValue("@Placement.Top")]
        Top,
        [StringValue("@Placement.TopRight")]
        TopRight,
        [StringValue("@Placement.Left")]
        Left,
        [StringValue("@Placement.LeftTop")]
        LeftTop,
        [StringValue("@Placement.LeftBottom")]
        LeftBottom,
        [StringValue("@Placement.Right")]
        Right,
        [StringValue("@Placement.RightTop")]
        RightTop,
        [StringValue("@Placement.RightBottom")]
        RightBottom,
        [StringValue("@Placement.BottomLeft")]
        BottomLeft,
        [StringValue("@Placement.BottomCenter")]
        BottomCenter,
        [StringValue("@Placement.Bottom")]
        Bottom,
        [StringValue("@Placement.BottomRight")]
        BottomRight
    }
}
