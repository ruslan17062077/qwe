using demo3.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для editZayavka.xaml
    /// </summary>
    public partial class editZayavka : Page
    {
        Partners partners;
        public editZayavka(Partners _partners)
        {
            InitializeComponent();
            type_partnerCb.ItemsSource = App.db.Partners_type.ToList();
            this.partners = _partners;
            if(partners.name != null)
            {
                nameTb.Text = partners.name;
            }
            if (partners.id_type != null)
            {
                type_partnerCb.SelectedItem = partners.Partners_type;
            }
            if (partners.name_direktor != null)
            {
                name_directorTb.Text = partners.name_direktor;
            }
            if (partners.email != null)
            {
                emailTb.Text = partners.email;
            }
            if (partners.phone != null)
            {
                phoneTb.Text = partners.phone;
            }
            if (partners.adress_partner != null)
            {
                adressTb.Text = partners.adress_partner;
            }
            if (partners.inn != null)
            {
                innTb.Text = partners.inn;
            }
            if (partners.rang != null)
            {
                rangTb.Text = partners.rang.ToString();
            }


        }

        private void goback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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
            if (phoneTb.Text.Trim().Length <=11)
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
                    partners.id_type = seltype.id;
                    partners.name = nameTb.Text;
                    partners.name_direktor = name_directorTb.Text;
                    partners.email = emailTb.Text;
                    partners.phone = phoneTb.Text;
                    partners.adress_partner = adressTb.Text;
                    partners.inn = innTb.Text;
                    partners.rang = int.Parse(rangTb.Text);
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
    }
}
