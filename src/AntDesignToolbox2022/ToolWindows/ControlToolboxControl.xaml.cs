using EnvDTE;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using AntDesignToolbox.ToolWindows.ViewModels;
using System.Windows.Media;
using EnvDTE80;

namespace AntDesignToolbox
{
    public partial class ControlToolboxControl : UserControl
    {
        public List<string> MyProperty { get; set; }
        public ControlToolboxControl()
        {
            InitializeComponent();
            this.DataContext = new ControlToolboxViewModel();           
        }

        private void Label_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                if (sender is Label l)
                {
                    try
                    {
                        var parent = VisualTreeHelper.GetParent(l) as ContentPresenter;
                        if(parent != null && parent.Content is TreeItemViewModel v)
                        {
                            DragDrop.DoDragDrop(parent, v.DefaultMarkup, DragDropEffects.Copy);
                        } 
                    }catch(Exception ex)
                    {

                    }
                }
                else
                {
                    DragDrop.DoDragDrop((DependencyObject)sender, "Hello World!", DragDropEffects.Copy);
                }
            }
            
        }
    }
}