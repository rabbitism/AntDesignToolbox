using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.LanguageServices;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AntDesignToolbox.Modules.CrudPage.ViewModels
{
    internal class CrudViewModel : BindableBase
    {
        private VisualStudioWorkspace _workspace;
        private ObservableCollection<ClassViewModel> _classViewModels;
        public ObservableCollection<ClassViewModel> ClassViewModels { get => _classViewModels; set => SetProperty(ref _classViewModels, value); }

        private ClassViewModel _selectedClassViewModel;
        public ClassViewModel SelectedClassViewModel { 
            get => _selectedClassViewModel;
            set {
                SetProperty(ref _selectedClassViewModel, value);
                UpdateClassHierarchy(value);
            } 
        }

        private ObservableCollection<PropertyCollectionViewModel> _hierarchy;
        public ObservableCollection<PropertyCollectionViewModel> Hierarchy { get => _hierarchy; set => SetProperty(ref _hierarchy, value); }


        public CrudViewModel()
        {
            ClassViewModels = new ObservableCollection<ClassViewModel>();
            Hierarchy = new ObservableCollection<PropertyCollectionViewModel>();
            ThreadHelper.JoinableTaskFactory.Run(InitializeAsync);

        }

        private async Task InitializeAsync()
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            IComponentModel componentModel = Package.GetGlobalService(typeof(SComponentModel)) as IComponentModel;

            VisualStudioWorkspace space = componentModel.GetService<VisualStudioWorkspace>();
            _workspace = space;

            var solutionItems = (await VS.Solutions.GetActiveItemsAsync())?.ToList();
            var item = solutionItems.FirstOrDefault();
            if (item.Type == SolutionItemType.PhysicalFolder)
            {
                // Right click on a folder, use this folder as Page output path, and load all class models in this solution
                await InitializeAllClassViewModels();
                await InitializeFolder(item);
            }
            else if (item.Type == SolutionItemType.PhysicalFile)
            {
                // Right click on a file, use this file as class models, and load all physical folders. 
                await InitializeClassViewModels(item);
                await InitializeAllFolders();
            }

            var path = solutionItems.First().FullPath;
            var document = space.CurrentSolution.Projects.First().Documents.FirstOrDefault(a => a.FilePath == path);



            //SemanticModel model = await document.GetSemanticModelAsync();
            //SyntaxTree tree = model.SyntaxTree;

            //CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

            //ClassDeclarationSyntax c = root.DescendantNodes().OfType<ClassDeclarationSyntax>().Single();

            //var classSymbol = model.GetDeclaredSymbol(c) as ITypeSymbol;


            //var baseT = classSymbol.BaseType;

            //var members = classSymbol.GetMembers();

            //var baseMembers = baseT.GetMembers();

            //var base2 = baseT.BaseType;
            //var base2members= base2.GetMembers();

            //foreach(var member in base2members)
            //{
            //    if(member.Kind== SymbolKind.Property)
            //    {
            //        IPropertySymbol s = member as IPropertySymbol;

            //    }
            //}
        }

        private async Task InitializeAllClassViewModels()
        {
            var documents = _workspace.CurrentSolution.Projects.SelectMany(a => a.Documents);
            foreach (var document in documents)
            {
                var semanticModel = await document.GetSemanticModelAsync();
                CompilationUnitSyntax root = semanticModel.SyntaxTree.GetCompilationUnitRoot();
                IEnumerable<ClassDeclarationSyntax> classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();
                foreach (var classDeclaration in classDeclarations)
                {
                    INamedTypeSymbol classSymbol = semanticModel.GetDeclaredSymbol(classDeclaration);
                    INamedTypeSymbol c = classSymbol;

                    bool isPage = false;
                    while (c != null)
                    {
                        if (c.Name == "ComponentBase")
                        {
                            isPage = true;
                            break;
                        }
                        c = c.BaseType;
                    }
                    if (isPage)
                    {
                        continue;
                    }
                    var classViewModel = new ClassViewModel
                    {
                        ClassName = classSymbol.Name,
                        ClassFullName = classSymbol.ContainingNamespace.ToString(),
                        Document = document,
                        ClassSymbol = classSymbol,
                    };
                    this.ClassViewModels.Add(classViewModel);
                }
            }
        }

        private async Task InitializeClassViewModels(SolutionItem item)
        {

        }

        private async Task InitializeAllFolders()
        {

        }

        private async Task InitializeFolder(SolutionItem item)
        {

        }

        private async Task UpdateClassHierarchy(ClassViewModel vm)
        {
            Hierarchy.Clear();
            //var semanticModel = await vm.Document.GetSemanticModelAsync();
            //CompilationUnitSyntax root = semanticModel.SyntaxTree.GetCompilationUnitRoot();
            var symbol = vm.ClassSymbol;
            while(symbol != null)
            {
                PropertyCollectionViewModel collection = new PropertyCollectionViewModel();
                collection.ClassName = symbol.Name;
                IEnumerable<ISymbol> members = symbol.GetMembers().Where(a => a.Kind == SymbolKind.Property && a.DeclaredAccessibility == Accessibility.Public);
                foreach (var member in members)
                {
                    if(member is IPropertySymbol ps)
                    {
                        collection.Properties.Add(new PropertyViewModel()
                        {
                            PropertyName = ps.Name,
                            PropertyType = ps.Type.ToDisplayString(),
                        });
                    }
                }
                if (collection.Properties.Count > 0)
                {
                    Hierarchy.Add(collection);
                }
                symbol = symbol.BaseType;
            }
        }
    }
}
