using EnvDTE;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace AntDesignToolbox
{
    public partial class ControlToolboxControl : UserControl
    {
        public List<string> MyProperty { get; set; }
        public ControlToolboxControl()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            VS.MessageBox.Show("AntDesignToolbox", "Button clicked");
        }

        private void button1_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Label b = sender as Label;
            DragDrop.DoDragDrop(b,b.Content.ToString(), DragDropEffects.Copy);

        }
    }
}