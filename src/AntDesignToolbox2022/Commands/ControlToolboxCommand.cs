namespace AntDesignToolbox
{
    [Command(PackageIds.ControlToolboxCommand)]
    internal sealed class ControlToolboxCommand : BaseCommand<ControlToolboxCommand>
    {
        protected override Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            return ControlToolboxWindow.ShowAsync();
        }
    }
}
