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
    /// Interaction logic for SurroundWithComponentWindow.xaml
    /// </summary>
    public partial class SurroundWithComponentWindow : Window
    {
        public SurroundWithComponentWindow()
        {
            InitializeComponent();
            var vm = new SurroundWithComponentViewModel();
            vm.OnCreateSucceedEventHandler += Vm_OnCreateSucceedEventHandler;
            this.DataContext = vm;
        }

        private void Vm_OnCreateSucceedEventHandler(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
