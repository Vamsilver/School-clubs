using SchoolClubs.BD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolClubs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SchoolEntities1 connection = new SchoolEntities1();
        public static User currentUser = new User();
    }
}
