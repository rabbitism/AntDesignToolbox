using Microsoft.VisualStudio.Imaging;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
    public class ControlToolboxViewModel : BindableBase
    {
        #region Properties
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

        private ObservableCollection<PropertyItemViewModel> _selectedProperties;

        public ObservableCollection<PropertyItemViewModel> SelectedProperties
        {
            get { return _selectedProperties; }
            set { SetProperty(ref _selectedProperties, value); }
        }

        #endregion


        public ControlToolboxViewModel()
        {
            SelectedProperties = new ObservableCollection<PropertyItemViewModel>();
            TreeItems = new ObservableCollection<TreeItemViewModel>()
            {
                new TreeItemViewModel(){
                    ControlName = "Button",
                    DefaultMarkup = @"<Button Type=""@ButtonType.Primary"">Primary</Button>",
                    Moniker = KnownMonikers.Button,
                    Properties = new ObservableCollection<PropertyItemViewModel>(){
                        new OptionsPropertyViewModel(){ 
                            PropertyName = "Type", 
                            DefaultValue="@ButtonType.Primary", 
                            SelectedValue = "@ButtonType.Primary", 
                            Options= new ObservableCollection<string>{ "@ButtonType.Primary", "@ButtonType.Link", "@ButtonType.Default"} },
                        new StringPropertyViewModel(){ PropertyName = "Content", DefaultValue = "", Value = ""},
                        new BooleanPropertyViewModel(){ PropertyName = "Danger", DefaultValue = false, Value = false }
                    }
                },
                new TreeItemViewModel(){ ControlName = "DatePicker", DefaultMarkup = @"<DatePicker TValue=""DateTime?"" Picker=""@DatePickerType.Date"" />", Moniker= KnownMonikers.DateTimePicker},
                new TreeItemViewModel(){ ControlName = "Layout", Moniker = KnownMonikers.LayoutPanel, DefaultMarkup = @"<Layout>
    <Header>Header</Header>
    <Layout>
        <Sider>

        </Sider>
        <Content>

        </Content>
    </Layout>
    <Footer>Footer</Footer>
</Layout>"},
                new TreeItemViewModel(){ ControlName = "Menu", Moniker = KnownMonikers.MenuItem, DefaultMarkup = @"<Menu>
    <MenuItem Key=""9"">Option 9</MenuItem>
    <MenuItem Key=""10"">Option 10</MenuItem>
    <MenuItem Key=""11"">Option 11</MenuItem>
    <MenuItem Key=""12"">Option 12</MenuItem>
</Menu>"}
            };




        }

    }
}