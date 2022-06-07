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

namespace BeautyDesktopApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPageWindow Window = new MainPageWindow();
            Window.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window5 Window = new Window5();
            Window.Show();
            Close();
        }

        private void POISK_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Chek_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Chek_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
