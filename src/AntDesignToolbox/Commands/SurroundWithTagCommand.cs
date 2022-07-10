using EnvDTE;
using Microsoft.VisualStudio.Threading;
using System.Linq;
using System.Text;

namespace AntDesignToolbox
{
    [Command(PackageGuids.AntDesignToolboxString, PackageIds.SurroundWithTagCommand)]
    internal sealed class SurroundWithTagCommand : BaseCommand<SurroundWithTagCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            Execute();
        }

        protected override void BeforeQueryStatus(EventArgs e)
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var activeDocument = AntDesignToolboxPackage.DTE.ActiveDocument.Object("TextDocument") as TextDocument;
            var language = activeDocument.Language;
            this.Command.Enabled = (language=="Razor");
        }

        private void Execute()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            var activeDocument = AntDesignToolboxPackage.DTE.ActiveDocument.Object("TextDocument") as TextDocument;
            TextSelection selection = activeDocument.Selection;
            var text = selection.Text;
            var lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var newText = GetNewText(lines);
            selection.ReplaceText(text, newText);
        }

        private Tuple<char,int> GetIndent(string[] lines)
        {
            if (lines is null || lines.Length == 0) return new Tuple<char, int>(' ', 0);
            string line = lines.FirstOrDefault(a=>a.Length>0);
            if(line is null) return new Tuple<char, int>(' ', 0);
            if (line.StartsWith("\t"))
            {
                int count = 0;
                foreach(char c in line)
                {
                    if (c == '\t')
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                return new Tuple<char, int>('\t', count);
            }
            else if(line.StartsWith(" "))
            {
                int count = 0;
                foreach (char c in line)
                {
                    if (c == ' ')
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                return new Tuple<char, int>(' ', count);
            }
            return new Tuple<char, int>(' ', 0);
        }

        private string GetNewText(string[] lines)
        {
            var tuple = GetIndent(lines);
            string indent = tuple.Item1 == ' ' ? "    " : "\t";
            string divIndent = new string(Enumerable.Repeat(tuple.Item1, tuple.Item2).ToArray());
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(divIndent + "<div>");
            foreach(var line in lines)
            {
                if (line.Length == 0)
                {
                    builder.AppendLine(line);
                }
                else{
                    builder.AppendLine(indent + line);
                }
            }
            builder.AppendLine(divIndent + "</div>");
            return builder.ToString();
        }

    }
}
