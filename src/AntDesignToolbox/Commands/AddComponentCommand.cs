namespace AntDesignToolbox
{
    [Command(PackageGuids.AntDesignToolboxString, PackageIds.AddComponentCommand)]
    internal sealed class AddComponentCommand : BaseCommand<AddComponentCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("AddComponentCommand", "Button clicked");
        }
    }
}
