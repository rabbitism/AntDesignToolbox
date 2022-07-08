using AntDesignToolbox.Commons;
using AntDesignToolbox.TextTemplates;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AntDesignToolbox.ViewModels
{
    public class AddComponentViewModel : BindableBase
    {
        private SolutionItem _solutionItem;
        private string _rootNamespace;
        private string _rootPath;

        #region Properties

        public event EventHandler OnCreateSucceedEventHandler;

        private string _componentName;

        public string ComponentName
        {
            get { return _componentName; }
            set { SetProperty(ref _componentName, value); AddCommand?.RaiseCanExecuteChanged(); }
        }

        private bool _codeBehind;

        public bool CodeBehind
        {
            get { return _codeBehind; }
            set { SetProperty(ref _codeBehind, value); }
        }

        private bool _css;

        public bool Css
        {
            get { return _css; }
            set { SetProperty(ref _css, value); }
        }

        #endregion Properties

        #region Commands

        public DelegateCommand AddCommand { get; set; }

        #endregion Commands

        public AddComponentViewModel()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            ThreadHelper.JoinableTaskFactory.Run(InitializeAsync);
            AddCommand = new DelegateCommand(() => ThreadHelper.JoinableTaskFactory.Run(OnAddAsync), CanAdd);
        }

        private async Task InitializeAsync()
        {
            var solutionItems = (await VS.Solutions.GetActiveItemsAsync()).ToList();
            if (solutionItems.Count != 1)
            {
                await VS.MessageBox.ShowErrorAsync("Cannot determine where to add this file. Please select only one folder. ");
                return;
            }
            _solutionItem = solutionItems.First();
            var ns = await ProjectHelper.GetNamespaceAsync(_solutionItem);
            
            _rootNamespace = ns;
            var path = ProjectHelper.GetContainingFolder(_solutionItem);
            _rootPath = path.FullName;
        }

        private async Task OnAddAsync()
        {
            try
            {
                await AddWithTemplateAsync(new RazorComponentTemplate(), "razor");
                if (CodeBehind)
                {
                    await AddWithTemplateAsync(new CodeBehindTemplate(), "razor.cs");
                }
                if (Css)
                {
                    await AddWithTemplateAsync(new CssTemplate(), "razor.css");
                }
            }
            catch(Exception ex)
            {
                await VS.MessageBox.ShowErrorAsync("Failed to create file. ", ex.Message);
            }
        }

        private bool CanAdd()
        {
            return ComponentName?.Length > 0;
        }

        private async Task AddWithTemplateAsync<T>(T template, string extension) where T : BaseTemplate
        {
            template.Session = GetCurrentSession();
            template.Initialize();
            string s = template.TransformText();

            string separator = _rootPath.EndsWith(Path.DirectorySeparatorChar.ToString()) ? string.Empty : Path.DirectorySeparatorChar.ToString();

            string path = _rootPath + separator + ComponentName + "." + extension;

            await FileHelper.ThrowIfExistAsync(path);
            await FileHelper.CreateTextFileAsync(path, s);

            var project = _solutionItem.GetContainingProject();
            await project?.AddExistingFilesAsync(path);
            // await VS.Documents.OpenViaProjectAsync(path);

            OnCreateSucceedEventHandler?.Invoke(this, null);
        }

        private Dictionary<string, object> GetCurrentSession()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result["Namespace"] = _rootNamespace;
            result["Name"] = ComponentName;
            result["IndependentCodeBehind"] = CodeBehind;
            return result;
        }
    }
}