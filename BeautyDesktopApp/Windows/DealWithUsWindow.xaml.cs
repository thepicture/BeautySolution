using System.Printing;
using System.Windows;
using System.Windows.Controls;

namespace BeautyDesktopApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для MakeOrderWindow.xaml
    /// </summary>
    public partial class DealWithUsWindow : Window
    {
        public DealWithUsWindow()
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

        private void PrintCommand(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            bool? dialogResult = printDialog.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                printDialog.PrintTicket.PageOrientation = PageOrientation.Landscape;
                printDialog.PrintVisual(PrintArea, "Визитка салона красоты");
            }
        }
    }
}
