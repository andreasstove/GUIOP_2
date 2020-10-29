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

namespace WPF_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Btn_add_click(object sender, RoutedEventArgs e)
        {
            var win2 = new AddCollecter();
            var depter = new Depter();
            var vm = new DepterViewModel(depter);
            win2.DataContext = vm;
            win2.ShowDialog();
            var vm2 = this.DataContext as MainWindowViewModel;
            vm2.depters.Add(depter);
        }

        private void ListBoxForDepters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListBoxForDepters.Focus();
        }

    }
}
