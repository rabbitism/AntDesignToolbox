using System.Windows;
using System.Windows.Controls;

namespace AntDesignToolbox
{
    public partial class ControlToolboxControl : UserControl
    {
        public ControlToolboxControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
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