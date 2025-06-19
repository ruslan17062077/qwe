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
    /// Логика взаимодействия для AddPartner.xaml
    /// </summary>
    public partial class AddPartner : Page
    {
        public AddPartner()
        {
            InitializeComponent();
            type_partnerCb.ItemsSource = App.db.Partners_type.ToList();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (type_partnerCb.SelectedIndex == -1)
            {
                error.AppendLine("Выбирете тип ");
            }
            if (nameTb.Text.Length == 0)
            {
                error.AppendLine("Введите название ");
            }
            if (name_directorTb.Text.Length == 0)
            {
                error.AppendLine("Введите Фио директора ");
            }
            if (emailTb.Text.Length == 0)
            {
                error.AppendLine("Введите email");
            }
            if (phoneTb.Text.Trim().Length <= 11)
            {
                error.AppendLine("Введите телефон ");
            }
            if (adressTb.Text.Length < 5)
            {
                error.AppendLine("Введите адресс ");
            }
            if (innTb.Text.Trim().Length < 9 && innTb.Text.Trim().Length > 13)
            {
                error.AppendLine("Введите инн от 10 до 12 ");
            }
            if (rangTb.Text.Length == 0)
            {
                error.AppendLine("Введите рейтинг ");
            }
            int rang = 0;
            Int64 phone = 0;
            Int64 inn = 0;
            try
            {
                if (!int.TryParse(rangTb.Text.Replace(" ", ""), out rang))
                {
                    error.AppendLine("рейтинг число ");
                }
            }
            catch
            {
                error.AppendLine("рейтинг число ");
            }
            if (rang < 0)
            {
                error.AppendLine("рейтинг положительное");
            }


            try
            {
                if (!Int64.TryParse(phoneTb.Text.Replace(" ", "").Trim(), out phone))
                {
                    error.AppendLine("телефон имеет только числа ");
                    MessageBox.Show(phoneTb.Text.Replace(" ", "").Trim());
                }
            }
            catch
            {
                error.AppendLine("телефон имеет только числа ");
            }

            try
            {
                if (!Int64.TryParse(innTb.Text.Replace(" ", "").Trim(), out inn))
                {
                    error.AppendLine("Инн имеет только числа");
                }
            }
            catch
            {
                error.AppendLine("Инн имеет только числа ");
            }


            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                var seltype = type_partnerCb.SelectedItem as Partners_type;

                try
                {
                    App.db.Partners.Add(new Partners() { id_type = seltype.id, name = nameTb.Text, name_direktor = name_directorTb.Text, email = emailTb.Text, phone = phoneTb.Text, adress_partner = adressTb.Text, inn = innTb.Text, rang = int.Parse(rangTb.Text) });
                    App.db.SaveChanges();
                    App.zayavka.refresh();
                    NavigationService.GoBack();
                }
                catch
                {
                    MessageBox.Show("Проверти данные");
                }
               
            }

        }

        private void goback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
