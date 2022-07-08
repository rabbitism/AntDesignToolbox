global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
global using System;
global using Task = System.Threading.Tasks.Task;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio;
using System.Runtime.InteropServices;
using System.Threading;

namespace AntDesignToolbox
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideToolWindow(typeof(ControlToolboxWindow.Pane), Style = VsDockStyle.Tabbed, Window = WindowGuids.Toolbox)]
    [ProvideToolWindowVisibility(typeof(ControlToolboxWindow), VSConstants.UICONTEXT.SolutionExists_string)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.AntDesignToolboxString)]
    public sealed class AntDesignToolboxPackage : ToolkitPackage
    {
        public static DTE2 DTE { get; private set; }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            DTE = (DTE2)await GetServiceAsync(typeof(DTE));
            await this.RegisterCommandsAsync();
            this.RegisterToolWindows();

        }

    }
}