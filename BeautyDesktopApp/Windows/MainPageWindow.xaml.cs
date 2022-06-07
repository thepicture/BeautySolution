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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainPageWindow : Window
    {
        public MainPageWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Uslugi_Click(object sender, RoutedEventArgs e)
        {
            Window3 Window = new Window3();
            Window.Show();
            Close();
        }

        private void Svyaz_Click(object sender, RoutedEventArgs e)
        {
            Window4 Window = new Window4();
            Window.Show();
            Close();
        }

        private void Onas_Click(object sender, RoutedEventArgs e)
        {
            Window5 Window = new Window5();
            Window.Show();
            Close();
        }

        private void Master_Click(object sender, RoutedEventArgs e)
        {
            Window6 Window = new Window6();
            Window.Show();
            Close();
        }
    }
}
