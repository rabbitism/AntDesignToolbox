using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using EnvDTE;

namespace AntDesignToolbox.ViewModels
{
    public class SurroundWithTagViewModel: BindableBase
    {
        public event EventHandler OnCreateSucceedEventHandler;
        public DelegateCommand GenerateCommand { get; set; }

        private string _text;
        public string Text { get => _text; set => SetProperty(ref _text, value); }

        public SurroundWithTagViewModel()
        {
            GenerateCommand = new DelegateCommand(()=>ThreadHelper.JoinableTaskFactory.Run(GenerateAsync));
        }


        
        public async Task GenerateAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            var activeDocument = AntDesignToolboxPackage.DTE.ActiveDocument.Object("TextDocument") as TextDocument;
            
            TextSelection selection = activeDocument.Selection;
            var text = selection.Text;
            var lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var newText = GetNewText(lines);
            selection.ReplaceText(text, newText);

            OnCreateSucceedEventHandler?.Invoke(null, null);
        }

        private Tuple<char, int> GetIndent(string[] lines)
        {
            if (lines is null || lines.Length == 0) return new Tuple<char, int>(' ', 0);
            string line = lines.FirstOrDefault(a => a.Length > 0);
            if (line is null) return new Tuple<char, int>(' ', 0);
            if (line.StartsWith("\t"))
            {
                int count = 0;
                foreach (char c in line)
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
            else if (line.StartsWith(" "))
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
            builder.AppendLine(divIndent + $"<{Text}>");
            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    builder.AppendLine(line);
                }
                else
                {
                    builder.AppendLine(indent + line);
                }
            }
            builder.AppendLine(divIndent + $"</{Text}>");
            return builder.ToString();
        }
    }
}
