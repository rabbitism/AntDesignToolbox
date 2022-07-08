using System;
using System.Collections.Generic;
using Prism.Mvvm;
using Prism.Commands;
using System.Linq;
using System.IO;
using System.Collections.ObjectModel;
using AntDesignToolbox.Commons;
using AntDesignToolbox.TextTemplates;

namespace AntDesignToolbox.ViewModels
{
	public class CreateCodeBehindViewModel : BindableBase
	{
        public event EventHandler OnCreateSucceedEventHandler;

        private bool _codeBehind;
        public bool CodeBehind
        {
            get { return _codeBehind; }
            set { SetProperty(ref _codeBehind, value); AddCommand?.RaiseCanExecuteChanged(); }
        }

        private bool _styleSheet;
        public bool StyleSheet
        {
            get { return _styleSheet; }
            set { SetProperty(ref _styleSheet, value); AddCommand?.RaiseCanExecuteChanged(); }
        }

        private string _selectedFlavor;
        public string SelectedFlavor
        {
            get { return _selectedFlavor; }
            set { SetProperty(ref _selectedFlavor, value); }
        }

        private ObservableCollection<string> _flavors;
        public ObservableCollection<string> Flavors
        {
            get { return _flavors; }
            set { SetProperty(ref _flavors, value); }
        }

        public DelegateCommand AddCommand { get; set; }
        public CreateCodeBehindViewModel()
        {
            AddCommand = new DelegateCommand(() => ThreadHelper.JoinableTaskFactory.Run(OnAddAsync), CanAdd);
            Flavors = new ObservableCollection<string>() { "CSS", "LESS", "SCSS" };
            SelectedFlavor = Flavors[0];
        }

        private async Task OnAddAsync()
        {
            var solutionItems = (await VS.Solutions.GetActiveItemsAsync()).ToList();
            var validSolutionItems = solutionItems.Where(IsRazorFile);

            foreach (var validItem in validSolutionItems)
            {
                await CreateAsync(validItem);
            }
            OnCreateSucceedEventHandler?.Invoke(null, null);
        }

        private bool CanAdd()
        {
            return CodeBehind || StyleSheet;
        }

        private bool IsRazorFile(SolutionItem item)
        {
            if (item is null) return false;
            if (item.Type != SolutionItemType.PhysicalFile) return false;
            var fileInfo = new FileInfo(item.FullPath);
            return fileInfo.Extension.ToLower() == ".razor";
        }

        private async Task CreateAsync(SolutionItem item)
        {
            // item: Extension: ".razor", Text: "Counter.razor"

            Project project = ProjectHelper.GetContainingProject(item);
            DirectoryInfo rootPath = ProjectHelper.GetContainingFolder(item.Parent);
            string @namespace = await ProjectHelper.GetNamespaceAsync(item.Parent);
            FileInfo info = new FileInfo(item.FullPath);
            var name = info.Name.Replace(info.Extension, "");
            if (CodeBehind)
            {
                await AddWithTemplateAsync(new CodeBehindTemplate(), rootPath.FullName, name, @namespace, "razor.cs", item, project);
            }
            if (StyleSheet)
            {
                var flavor = string.IsNullOrEmpty(SelectedFlavor) ? "css" : SelectedFlavor.ToLower();
                await AddWithTemplateAsync(new CssTemplate(), rootPath.FullName, name, @namespace, $"razor.{flavor}", item, project);
            }
        }

        private async Task AddWithTemplateAsync<T>(
            T template, 
            string rootPath, 
            string name, 
            string @namespace,
            string extension,
            SolutionItem item,
            Project project
            ) where T : BaseTemplate
        {
            try
            {
                template.Session = GetSession(name, @namespace);
                template.Initialize();
                string s = template.TransformText();

                string separator = rootPath.EndsWith(Path.DirectorySeparatorChar.ToString()) ? string.Empty : Path.DirectorySeparatorChar.ToString();

                string path = rootPath + separator + name + "." + extension;
                if (File.Exists(path))
                {
                    return;
                }
                await FileHelper.CreateTextFileAsync(path, s);
                await project?.AddExistingFilesAsync(path);
            }
            catch(Exception ex)
            {
                
            }
        }

        private Dictionary<string, object> GetSession(string name, string @namespace)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result["Namespace"] = @namespace;
            result["Name"] = name;
            return result;
        }

    }
}