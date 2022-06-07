using BeautyDesktopApp.Models.Entities;
using System.Windows;

namespace BeautyDesktopApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Клиент Customer { get; set; }
        public static Работник Worker { get; set; }
    }
}
