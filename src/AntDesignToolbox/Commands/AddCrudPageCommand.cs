using AntDesignToolbox.Modules.CrudPage.Views;
using System.Linq;

namespace AntDesignToolbox
{
    [Command(PackageGuids.AntDesignToolboxString,  PackageIds.AddCrudPageCommand)]
    internal sealed class AddCrudPageCommand : BaseCommand<AddCrudPageCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            // await VS.MessageBox.ShowWarningAsync("AddCrudPageCommand", "Button clicked");
            await VS.Windows.ShowDialogAsync(new CrudWindow());
        }

        protected override async void BeforeQueryStatus(EventArgs e)
        {
            base.BeforeQueryStatus(e);
            var solutionItems = ThreadHelper.JoinableTaskFactory.Run(VS.Solutions.GetActiveItemsAsync)?.ToList();
            if(solutionItems!= null && solutionItems.Count==1)
            {
                this.Command.Enabled = true;
            }
            else
            {
                this.Command.Enabled = false;
            }
        }
    }
}
