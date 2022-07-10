namespace AntDesignToolbox
{
    [Command(PackageGuids.AntDesignToolboxString,  PackageIds.AddCrudPageCommand)]
    internal sealed class AddCrudPageCommand : BaseCommand<AddCrudPageCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("AddCrudPageCommand", "Button clicked");
        }
    }
}
