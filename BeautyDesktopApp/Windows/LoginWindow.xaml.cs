using BeautyDesktopApp.Models.Entities;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace BeautyDesktopApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, IDataErrorInfo, INotifyPropertyChanged
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Error
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this[nameof(Login)]))
                    return nameof(Login);
                if (!string.IsNullOrWhiteSpace(this[nameof(Password)]))
                    return nameof(Password);
                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Login))
                    if (string.IsNullOrWhiteSpace(Login) || Login.Length < 5)
                        return "Это поле введено некорректно!";
                if (columnName == nameof(Password))
                    if (string.IsNullOrWhiteSpace(Password) || Password.Length < 5)
                        return "Это поле введено некорректно!";
                return null;
            }
        }

        [PropertyChanged.DependsOn(nameof(Login), nameof(Password))]
        public bool IsCanSignIn => Error == null;

        public LoginWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            using (BeautyBaseEntities entities = new BeautyBaseEntities())
            {
                var customer = entities.Клиент.FirstOrDefault(c => c.Логин == Login && c.Пароль == Password);
                if (customer is Клиент)
                {
                    MainPageWindow Window = new MainPageWindow();
                    Window.Show();
                    Close();
                    MessageBox.Show("Добро пожаловать!");
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
        }

        private void OpenRegistrationWindow(object sender, RoutedEventArgs e)
        {
            RegistrationWindow Window = new RegistrationWindow();
            Window.Show();
            Close();
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

