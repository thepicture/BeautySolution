using System.Windows;
using System.Windows.Controls;

namespace BeautyDesktopApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AboutUsWindow.xaml
    /// </summary>
    public partial class AboutUsWindow : Window
    {
        public AboutUsWindow()
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
            MasterWorksWindow Window = new MasterWorksWindow();
            Window.Show();
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
