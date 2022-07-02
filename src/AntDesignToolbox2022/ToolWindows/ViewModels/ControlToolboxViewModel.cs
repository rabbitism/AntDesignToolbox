using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.Text.Editor;
using Prism.Mvvm;

namespace AntDesignToolbox.ToolWindows.ViewModels
{
	public class ControlToolboxViewModel : BindableBase
	{
        #region Properties
        public ObservableCollection<TreeItemViewModel> TreeItems { get; set; }
        #endregion


        public ControlToolboxViewModel()
        {
            TreeItems = new ObservableCollection<TreeItemViewModel>()
            {
                new TreeItemViewModel(){ ControlName = "Button", DefaultMarkup = @"<Button Type=""@ButtonType.Primary"">Primary</Button>"},
                new TreeItemViewModel(){ ControlName = "DatePicker", DefaultMarkup = @"<DatePicker TValue=""DateTime?"" Picker=""@DatePickerType.Date"" />"},
                new TreeItemViewModel(){ ControlName = "Layout", DefaultMarkup = @"<Layout>
        <Header>Header</Header>
        <Layout>
            <Sider>

            </Sider>
            <Content>

            </Content>
        </Layout>
        <Footer>Footer</Footer>
    </Layout>"},
                new TreeItemViewModel(){ ControlName = "Menu", DefaultMarkup = @"<Menu>
        <MenuItem Key=""9"">Option 9</MenuItem>
        <MenuItem Key=""10"">Option 10</MenuItem>
        <MenuItem Key=""11"">Option 11</MenuItem>
        <MenuItem Key=""12"">Option 12</MenuItem>
    </Menu>"}
            };


            
            
        }

    }
}