using EnvDTE;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace AntDesignToolbox.ViewModels
{
    internal class SurroundWithComponentViewModel : BindableBase
    {
        public event EventHandler OnCreateSucceedEventHandler;

        private ComponentItem _selectedComponent;
        public ComponentItem SelectedComponent
        {
            get => _selectedComponent;
            set
            {
                SetProperty(ref _selectedComponent, value);
                ConfirmCommand.RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<ComponentItem> _components;
        public ObservableCollection<ComponentItem> Components { get => _components; set => SetProperty(ref _components, value); }

        public DelegateCommand ConfirmCommand { get; set; }

        public SurroundWithComponentViewModel()
        {
            InitializeComponents();
            ConfirmCommand = new DelegateCommand(() => { ThreadHelper.JoinableTaskFactory.Run(GenerateAsync); }, CanGenerate);
        }

        private void InitializeComponents()
        {
            var items = new List<ComponentItem>
            {
                new ComponentItem{ ComponentName = "CascadingValue", OpenTag = "<CascadingValue TValue=\"object\">", CloseTag = "</CascadingValue>" },
                new ComponentItem{ ComponentName = "ChildContent", OpenTag = "<ChildContent>", CloseTag = "</ChildContent>" },
                new ComponentItem{ ComponentName = "Unbound", OpenTag = "<Unbound>", CloseTag = "</Unbound>" },
                new ComponentItem{ ComponentName = "Popconfirm", OpenTag = @"<Popconfirm Title=""This is Title"" OkText=""Yes"" CancelText=""No"">", CloseTag = "</Popconfirm>" },
            };
            var ordered = items.OrderBy(a => a.ComponentName);
            Components = new ObservableCollection<ComponentItem>(ordered);
        }

        private bool CanGenerate()
        {
            return SelectedComponent != null;
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
            builder.AppendLine(divIndent + SelectedComponent.OpenTag);
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
            builder.AppendLine(divIndent + SelectedComponent.CloseTag);
            return builder.ToString();
        }

    }

    internal class ComponentItem : BindableBase
    {
        private string _componentName;
        public string ComponentName { get => _componentName; set => SetProperty(ref _componentName, value); }

        public string OpenTag { get; set; }
        public string CloseTag { get; set; }
    }
}
