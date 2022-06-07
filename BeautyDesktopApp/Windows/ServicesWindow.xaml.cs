using System.Windows;

namespace BeautyDesktopApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServicesWindow.xaml
    /// </summary>
    public partial class ServicesWindow : Window
    {
        public ServicesWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MakeOrderWindow Window = new MakeOrderWindow();
            Window.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainPageWindow Window = new MainPageWindow();
            Window.Show();
            Close();
        }
    }
}
