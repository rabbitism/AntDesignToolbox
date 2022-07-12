using AntDesignToolbox.Views;

namespace AntDesignToolbox
{
    [Command(PackageGuids.AntDesignToolboxString, PackageIds.SurroundWithComponentCommand)]
    internal sealed class SurroundWithComponentCommand : BaseCommand<SurroundWithComponentCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            // await VS.MessageBox.ShowWarningAsync("SurroundWithComponentCommand", "Button clicked");
            await VS.Windows.ShowDialogAsync(new SurroundWithComponentWindow());
        }
    }
}
