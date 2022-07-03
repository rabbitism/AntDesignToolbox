using Microsoft.VisualStudio.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AntDesignToolbox
{
    public class ControlToolboxWindow : BaseToolWindow<ControlToolboxWindow>
    {
        public override string GetTitle(int toolWindowId) => "Ant Design Blazor";

        public override Type PaneType => typeof(Pane);

        public override Task<FrameworkElement> CreateAsync(int toolWindowId, CancellationToken cancellationToken)
        {
            return Task.FromResult<FrameworkElement>(new ControlToolboxControl());
        }

        [Guid("068cac5e-295a-46c8-bd56-cd45ccf6be60")]
        internal class Pane : ToolkitToolWindowPane
        {
            public Pane()
            {
                BitmapImageMoniker = KnownMonikers.Blazor;
            }
        }
    }
}