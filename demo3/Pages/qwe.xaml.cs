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
using System.Xml.Linq;

namespace demo3.Pages
{
    /// <summary>
    /// Логика взаимодействия для qwe.xaml
    /// </summary>
    public partial class qwe : Page
    {
        public qwe()
        {
            InitializeComponent();
            refresh();
            var partners = App.db.Partners.ToList();
            partners.Add(new Partners() { name = "все" });
            partnerCb.ItemsSource = partners;

        }
        public void refresh()
        {
            List<Product> itemOne = new List<Product>();
            var selpartner = partnerCb.SelectedItem as Partners;
            if (partnerCb.SelectedIndex == -1)
            {



                foreach (var item in App.db.Partner_product.ToList())
                {
                    if (itemOne.Count == 0)
                    {
                        itemOne.Add(item.Product);
                    }
                    else
                    {
                        if (itemOne.FirstOrDefault(x => x.id == item.id_product) == null)
                        {
                            itemOne.Add(item.Product);
                        }
                    }
                }
                foreach (var i in itemOne)
                {
                    i.Count = Count(null, i.id);
                }
                namesss.ItemsSource = itemOne;

            }
            else
            {
                if (selpartner.name != "все")
                {
                    foreach (var item in App.db.Partner_product.Where(x => x.id_partnera == selpartner.id).ToList())
                    {
                        if (itemOne.Count == 0)
                        {
                            itemOne.Add(item.Product);
                        }
                        else
                        {
                            if (itemOne.FirstOrDefault(x => x.id == item.id_product) == null)
                            {
                                itemOne.Add(item.Product);
                            }
                        }
                    }
                    foreach (var i in itemOne)
                    {
                        i.Count = Count(selpartner.id, i.id);
                    }
                    namesss.ItemsSource = itemOne;
                }
                else
                {
                    foreach (var item in App.db.Partner_product.ToList())
                    {
                        if (itemOne.Count == 0)
                        {
                            itemOne.Add(item.Product);
                        }
                        else
                        {
                            if (itemOne.FirstOrDefault(x => x.id == item.id_product) == null)
                            {
                                itemOne.Add(item.Product);
                            }
                        }
                    }
                    foreach (var i in itemOne)
                    {
                        i.Count = Count(null, i.id);
                    }
                    namesss.ItemsSource = itemOne;
                }
            }
           
        }
        public int Count(int? id_p, int id_prod)
        {
            if(id_p != null)
            {
                int count = 0;
                foreach (var item in App.db.Partner_product.Where(x => x.id_product == id_prod && x.id_partnera == id_p))
                {
                    count += item.count ?? 0;
                }
                return count;
            }
            else
            {
                int count = 0;
                foreach (var item in App.db.Partner_product.Where(x => x.id_product == id_prod).ToList())
                {
                    count += item.count ?? 0;
                }
                return count;
            }
          

        }

        private void goback_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void partnerCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh();
        }
    }
}
