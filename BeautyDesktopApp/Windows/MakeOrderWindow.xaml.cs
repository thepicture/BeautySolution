using System.Windows;

namespace BeautyDesktopApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для MakeOrderWindow.xaml
    /// </summary>
    public partial class MakeOrderWindow : Window
    {
        public MakeOrderWindow()
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
            ServicesWindow Window = new ServicesWindow();
            Window.Show();
            Close();
        }

        private void GoToOrderCreationWindow(object sender, RoutedEventArgs e)
        {
            if (App.Customer == null)
            {
                MessageBox.Show("Только клиент может записаться на услугу, вы сотрудник!");
                return;
            }

            OrderCreationWindow orderCreationWindow = new OrderCreationWindow();
            orderCreationWindow.Show();
            Close();
        }
    }
}
