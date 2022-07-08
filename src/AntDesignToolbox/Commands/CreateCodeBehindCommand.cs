using AntDesignToolbox.Views;
using System.Collections.Generic;

namespace AntDesignToolbox
{
    [Command(PackageGuids.AntDesignToolboxString, PackageIds.CreateCodeBehindCommand)]
    internal sealed class CreateCodeBehindCommand : BaseCommand<CreateCodeBehindCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.Windows.ShowDialogAsync(new CreateCodeBehindWindow());
        }

        protected override void BeforeQueryStatus(EventArgs e)
        {
            IEnumerable<SolutionItem> solutionItems = ThreadHelper.JoinableTaskFactory.Run(VS.Solutions.GetActiveItemsAsync);
            bool enable = true;
            foreach(var item in solutionItems)
            {
                if(item.Type != SolutionItemType.PhysicalFile)
                {
                    enable = false;
                }
            }
            this.Command.Enabled = enable;

        }
    }
}
