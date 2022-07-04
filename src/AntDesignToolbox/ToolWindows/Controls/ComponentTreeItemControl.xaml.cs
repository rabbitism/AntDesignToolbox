using AntDesignToolbox.ToolWindows.ViewModels;
using Microsoft.VisualStudio.Imaging;
using Microsoft.VisualStudio.Imaging.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AntDesignToolbox.ToolWindows.Controls
{
    /// <summary>
    /// Interaction logic for ComponentTreeItemControl.xaml
    /// </summary>
    public partial class ComponentTreeItemControl : UserControl
    {
        public ComponentTreeItemControl()
        {
            InitializeComponent();
        }


        public ImageMoniker Moniker
        {
            get { return (ImageMoniker)GetValue(MonikerProperty); }
            set { SetValue(MonikerProperty, value); }
        }
        public static readonly DependencyProperty MonikerProperty =
            DependencyProperty.Register(nameof(Moniker), typeof(ImageMoniker), typeof(ComponentTreeItemControl), new PropertyMetadata(KnownMonikers.None));



        public string ComponentName
        {
            get { return (string)GetValue(ComponentNameProperty); }
            set { SetValue(ComponentNameProperty, value); }
        }
        public static readonly DependencyProperty ComponentNameProperty =
            DependencyProperty.Register(nameof(ComponentName), typeof(string), typeof(ComponentTreeItemControl), new PropertyMetadata(string.Empty));

        private void root_MouseLeave(object sender, MouseEventArgs e)
        {
            if(e.LeftButton== MouseButtonState.Pressed)
            {
                if (this.DataContext != null && this.DataContext is TreeItemViewModel vm)
                {
                    DragDrop.DoDragDrop(sender as DependencyObject, vm.DefaultMarkup, DragDropEffects.Copy);
                }
            }
            
        }
    }
}
