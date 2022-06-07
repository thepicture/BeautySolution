using BeautyDesktopApp.Models.Entities;
using System;
using System.ComponentModel;
using System.Windows;

namespace BeautyDesktopApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window, IDataErrorInfo, INotifyPropertyChanged
    {
        public string Login { get; set; }

        public string FirstPassword { get; set; }
        public string SecondPassword { get; set; }

        public string Error
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this[nameof(Login)]))
                    return nameof(Login);
                if (!string.IsNullOrWhiteSpace(this[nameof(FirstPassword)]))
                    return nameof(FirstPassword);
                if (!string.IsNullOrWhiteSpace(this[nameof(SecondPassword)]))
                    return nameof(SecondPassword);
                return null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == nameof(Login))
                    if (string.IsNullOrWhiteSpace(Login) || Login.Length < 5)
                        return "Введите логин от 5 символов!";
                if (columnName == nameof(FirstPassword))
                    if (string.IsNullOrWhiteSpace(FirstPassword) || FirstPassword.Length < 5)
                        return "Введите пароль от 5 символов!";
                if (columnName == nameof(SecondPassword))
                    if (string.IsNullOrWhiteSpace(SecondPassword) || FirstPassword != SecondPassword)
                        return "Пароли не совпадают!";
                return null;
            }
        }

        [PropertyChanged.DependsOn(nameof(Login), nameof(FirstPassword), nameof(SecondPassword))]
        public bool IsCanRegister => Error == null;

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnGoBack(object sender, RoutedEventArgs e)
        {
            LoginWindow Window = new LoginWindow();
            Window.Show();
            Close();
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    var customer = new Клиент
                    {
                        Логин = Login,
                        Пароль = FirstPassword
                    };
                    entities.Клиент.Add(customer);
                    entities.SaveChanges();
                    OnGoBack(this, new RoutedEventArgs());
                    MessageBox.Show("Регистрация прошла успешно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
