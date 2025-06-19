using demo3.Db;
using demo3.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace demo3
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static demo3Entities db = new demo3Entities();
        public static ZayavkaPartnerListPage zayavka;
    }
}
