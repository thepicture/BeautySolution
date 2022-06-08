using BeautyDesktopApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace BeautyDesktopApp.Windows
{
    /// <summary>
    /// Interaction logic for CustomersWindow.xaml
    /// </summary>
    public partial class CustomersWindow : Window, INotifyPropertyChanged
    {
        public Клиент Customer { get; set; }
        public ObservableCollection<Клиент> Customers { get; set; }

        public CustomersWindow()
        {
            InitializeComponent();
            LoadCustomersAsync();
            Customer = new Клиент();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void LoadCustomersAsync()
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    List<Клиент> customers = await entities.Клиент.ToListAsync();
                    Customers = new ObservableCollection<Клиент>(customers);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OnDeleteCustomer(object sender, RoutedEventArgs e)
        {
            MessageBoxResult questionResult = MessageBox
                .Show("Удалить клиента?",
                      "Подвердите действие",
                      MessageBoxButton.YesNo,
                      MessageBoxImage.Question);
            if (questionResult != MessageBoxResult.Yes)
            {
                return;
            }
            Клиент customer = ((dynamic)sender).DataContext;
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    entities.Entry(customer).State = EntityState.Deleted;
                    entities.SaveChanges();
                }
                MessageBox.Show("Клиент удалён!");
                LoadCustomersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OnCustomerSave(object sender, RoutedEventArgs e)
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    if (Customer.ID_клиента == 0)
                    {
                        entities.Entry(Customer).State = EntityState.Added;
                        entities.SaveChanges();
                        MessageBox.Show("Клиент добавлен!");
                        LoadCustomersAsync();
                    }
                    else
                    {
                        var customerFromDb = entities.Клиент.First(c => c.ID_клиента == Customer.ID_клиента);
                        entities.Entry(customerFromDb).CurrentValues.SetValues(Customer);
                        entities.SaveChanges();
                        MessageBox.Show("Клиент изменён!");
                        LoadCustomersAsync();
                    }
                }
                LoadCustomersAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void OnGoBack(object sender, RoutedEventArgs e)
        {
            MainPageWindow mainPageWindow = new MainPageWindow();
            mainPageWindow.Show();
            Close();
        }

        private void OnEditCustomer(object sender, RoutedEventArgs e)
        {
            Клиент editingCustomer = ((dynamic)sender).DataContext;
            Customer = new Клиент
            {
                ID_клиента = editingCustomer.ID_клиента,
                Дата_рождения = editingCustomer.Дата_рождения,
                Логин = editingCustomer.Логин,
                Пароль = editingCustomer.Пароль,
                ФИО = editingCustomer.ФИО,
                Номер_телефона = editingCustomer.Номер_телефона,
            };
            CustomerPassword.BindablePassword.Password = editingCustomer.Пароль;
            AddCustomerButton.Content = "Обновить текущего клиента";
            MessageBox.Show("Вы вошли в режим изменения");
        }

        private void OnAddNewCustomer(object sender, RoutedEventArgs e)
        {
            Customer = new Клиент();
            AddCustomerButton.Content = "Добавить нового клиента";
            MessageBox.Show("Поля подготовлены");
        }
    }
}
