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

        private void Label_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                if (sender is ComponentTreeItemControl l)
                {
                    try
                    {
                        if(l.DataContext is TreeItemViewModel v)
                        {
                            DragDrop.DoDragDrop(l, v.DefaultMarkup, DragDropEffects.Copy);
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


        private async void Label_MouseMove_1(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                if(sender is Label l)
                {
                    System.Diagnostics.Debug.WriteLine("Dragged");
                    if(this.DataContext is ControlToolboxViewModel v && v.SelectedItem!=null)
                    {
                        XElement element = new XElement(v.SelectedItem.ControlName);
                        foreach(var property in v.SelectedItem.Properties)
                        {
                            if(property is StringPropertyViewModel sp)
                            {
                                if(sp.PropertyName == "Content")
                                {
                                    element.Add(new XText(sp.Value));
                                }
                                else
                                {
                                    element.Add(new XAttribute(sp.PropertyName, sp.Value));
                                }
                            }
                            else if(property is BooleanPropertyViewModel bp)
                            {
                                element.Add(new XAttribute(bp.PropertyName, bp.Value.ToString().ToLower()));
                            }
                            else if(property is OptionsPropertyViewModel op)
                            {
                                element.Add(new XAttribute(op.PropertyName, op.SelectedValue));
                            }
                        }

                        string s = element.ToString(SaveOptions.None)+"\n";
                        DragDrop.DoDragDrop(l, s, DragDropEffects.Copy);
                        //StringBuilder builder = new StringBuilder();
                        //builder.AppendLine("Testing----------");
                        //builder.Append("Control Name: ");
                        //builder.AppendLine(v.SelectedItem.ControlName);
                        //foreach(var item in v.SelectedItem.Properties)
                        //{
                        //    if(item is StringPropertyViewModel sp)
                        //    {
                        //        builder.Append(sp.PropertyName + ": ");
                        //        builder.AppendLine(sp.Value);
                        //    }
                        //    else if(item  is BooleanPropertyViewModel bp)
                        //    {
                        //        builder.Append(bp.PropertyName + ": ");
                        //        builder.AppendLine(bp.Value.ToString());
                        //    }
                        //    else if(item is OptionsPropertyViewModel op)
                        //    {
                        //        builder.Append(op.PropertyName + ": ");
                        //        builder.AppendLine(op.SelectedValue);
                        //    }
                        //}

                        //builder.AppendLine("Test Finished--------------");
                        //DragDrop.DoDragDrop(l, builder.ToString(), DragDropEffects.Copy);
                    }
                    
                }
            }
        }

    }
}