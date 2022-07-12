using AntDesignToolbox.ViewModels;
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
using System.Windows.Shapes;

namespace AntDesignToolbox.Views
{
    /// <summary>
    /// Interaction logic for SurroundWithTagWindow.xaml
    /// </summary>
    public partial class SurroundWithTagWindow : Window
    {
        public SurroundWithTagWindow()
        {
            InitializeComponent();
            var vm = new SurroundWithTagViewModel();
            vm.OnCreateSucceedEventHandler += Vm_OnCreateSucceedEventHandler;
            this.DataContext = vm;
            textBox.Focus();
        }

        private void Vm_OnCreateSucceedEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter && this.DataContext is SurroundWithTagViewModel vm)
            {
                await vm.GenerateAsync();
            }
        }
    }
}
