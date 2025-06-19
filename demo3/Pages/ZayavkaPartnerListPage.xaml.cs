using demo3.Db;
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

namespace demo3.Pages
{
    /// <summary>
    /// Логика взаимодействия для ZayavkaPartnerListPage.xaml
    /// </summary>
    public partial class ZayavkaPartnerListPage : Page
    {
        public ZayavkaPartnerListPage()
        {
            InitializeComponent();
            
            App.zayavka = this;
            refresh();
        }
        public void refresh()
        {
            LV.ItemsSource = App.db.Partners.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPartner());
        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selLv = LV.SelectedItem as Partners;
            if (selLv != null)
            {
                NavigationService.Navigate(new editZayavka(selLv));
            }
            LV.SelectedItem = null;


         }

        private void goback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
