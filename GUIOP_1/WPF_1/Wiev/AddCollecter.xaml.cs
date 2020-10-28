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


namespace WPF_1
{
    /// <summary>
    /// Interaction logic for AddCollecter.xaml
    /// </summary>
    public partial class AddCollecter : Window
    {
        public AddCollecter()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BtnAnnulere_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void BtnGem_Click(object sender, RoutedEventArgs e)
        {
            var gem = DataContext as MainWindowViewModel;

            gem.AddNewDepter();
            txtB_Name.Focus();
            var win1 = new MainWindow();
            //win1.ListBoxForDepters
            win1.ListBoxForDepters.SelectedIndex = win1.ListBoxForDepters.Items.Count - 1;
            //DialogResult = true;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
