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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow Window = new LoginWindow();
            Window.Show();
            Close();

            string login = textboxlogin.Text;
            string pass = textboxpass.Password;
            string pass1 = textboxpass1.Password;


            if (login.Length < 5)
            {
                textboxlogin.ToolTip = "Это поле введено не корректно!";
                textboxlogin.Background = Brushes.Red;
            }
            else if (pass.Length < 5)
            {
                textboxpass.ToolTip = "Это поле введено не корректно!";
                textboxpass.Background = Brushes.Red;
            }
            else
            {
                textboxlogin.ToolTip = "";
                textboxlogin.Background = Brushes.Transparent;
                textboxpass.ToolTip = "";
                textboxpass.Background = Brushes.Transparent;


                MessageBox.Show("Регистрация прошла успешно!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoginWindow Window = new LoginWindow();
            Window.Show();
            Close();
        }
    }
}
