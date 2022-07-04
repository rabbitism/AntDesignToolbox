using Microsoft.VisualStudio.Imaging;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class ControlToolboxViewModel : BindableBase
    {
        #region Properties
        private List<TreeItemViewModel> _allControls;
        public ObservableCollection<TreeItemViewModel> FixedTreeItems { get; set; }
        public ObservableCollection<TreeItemViewModel> TreeItems { get; set; }
        private TreeItemViewModel _selectedTreeItem;

        public TreeItemViewModel SelectedItem
        {
            get { return _selectedTreeItem; }
            set
            {
                SetProperty(ref _selectedTreeItem, value);
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
                SearchByText(value);
            }
        }

        #endregion


        public ControlToolboxViewModel()
        {
            var items = new List<TreeItemViewModel>()
            {
                new TreeItemViewModel(){ Component = ViewModelSourceHelper.ButtonViewModel },
                new TreeItemViewModel(){ Component = ViewModelSourceHelper.TextViewModel },
                new TreeItemViewModel(){ Component = ViewModelSourceHelper.TitleViewModel },
                new TreeItemViewModel(){ Component = ViewModelSourceHelper.ParagraphViewModel },
                new TreeItemViewModel(){ Component = ViewModelSourceHelper.DividerViewModel },
                new TreeItemViewModel(){ Component = ViewModelSourceHelper.SpaceViewModel },
                new TreeItemViewModel(){ Component = ViewModelSourceHelper.LayoutViewModel },
                new TreeItemViewModel(){ Component = ViewModelSourceHelper.BreadcrumbViewModel },
                new TreeItemViewModel(){ Component = ViewModelSourceHelper.PageHeaderViewModel },
            };

            _allControls = items.OrderBy(a=>a.Component.ControlName).ToList();

            TreeItems = new ObservableCollection<TreeItemViewModel>(items.OrderBy(a => a.Component.ControlName));
        }


        public void DragCompiledComponent(DependencyObject source)
        {
            DragDrop.DoDragDrop(source, null, DragDropEffects.Copy);
        }

        private void SearchByText(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                TreeItems.Clear();
                foreach(var item in _allControls)
                {
                    TreeItems.Add(item);
                }
                return;
            }
            var items = _allControls.Where(a => a.Component.ControlName.ToLower().Contains(s.ToLower())).OrderBy(a => a.Component.ControlName);
            TreeItems.Clear();
            foreach(var item in items)
            {
                TreeItems.Add(item);
            }
        }
    }
}