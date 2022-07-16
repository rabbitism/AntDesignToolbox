using AntDesignToolbox.Modules.CrudPage.ViewModels;
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

namespace AntDesignToolbox.Modules.CrudPage.Views
{
    /// <summary>
    /// Interaction logic for CrudWindow.xaml
    /// </summary>
    public partial class CrudWindow : Window
    {
        public CrudWindow()
        {
            InitializeComponent();
            var vm = new CrudViewModel();
            this.DataContext = vm;
        }
    }
}
