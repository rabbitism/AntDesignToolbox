using AntDesignToolbox.Views;
using System.Linq;

namespace AntDesignToolbox
{
    [Command(PackageGuids.AntDesignToolboxString, PackageIds.AddComponentCommand)]
    internal sealed class AddComponentCommand : BaseCommand<AddComponentCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var solutionItems = (await VS.Solutions.GetActiveItemsAsync())?.ToList();
            if (solutionItems is null || solutionItems.Count != 1)
            {
                await VS.MessageBox.ShowErrorAsync("Cannot determine where to add this component. Please select only one folder. ");
                return;
            }
            await VS.Windows.ShowDialogAsync(new AddComponentWindow());
        }
    }
}
