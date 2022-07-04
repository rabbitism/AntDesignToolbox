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
using System.Text;
using Microsoft.VisualStudio.Text.Editor;
using System.Xml.Linq;
using AntDesignToolbox.ToolWindows.Controls;

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


        private void Label_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                if(sender is Label l)
                {
                    System.Diagnostics.Debug.WriteLine("Dragged");
                    if(this.DataContext is ControlToolboxViewModel v && v.SelectedItem!=null)
                    {

                        string s = v.SelectedItem.Component.GetCompiledComponent();
                        DragDrop.DoDragDrop(l, s, DragDropEffects.Copy);
                    }
                    
                }
            }
        }

        private void Label_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Label)
            {
                System.Diagnostics.Debug.WriteLine("Dragged");
                if (this.DataContext is ControlToolboxViewModel v && v.SelectedItem != null)
                {

                    string s = v.SelectedItem.Component.GetCompiledComponent();
                    Clipboard.SetText(s);
                }

            }
        }
    }
}