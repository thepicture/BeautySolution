using BeautyDesktopApp.Models.Entities;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for OrderCreationWindow.xaml
    /// </summary>
    public partial class OrderCreationWindow : Window, INotifyPropertyChanged
    {
        private Услуга selectedService;

        public Запись_на_услугу CurrentOrder { get; set; }

        public ObservableCollection<Услуга> Services { get; set; }
        public ObservableCollection<Запись_на_услугу> MyOrders { get; set; }



        public Услуга SelectedService
        {
            get => selectedService;
            set
            {
                selectedService = value;
            }
        }

        public OrderCreationWindow()
        {
            InitializeComponent();
            CurrentOrder = new Запись_на_услугу
            {
                Дата_начала = DateTime.Now.AddDays(1),
            };
            LoadServicesAsync();
            LoadMyOrdersAsync();
        }

        private async void LoadMyOrdersAsync()
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    List<Запись_на_услугу> types = await entities.Запись_на_услугу
                        .Include(o => o.Услуга)
                        .Where(o => o.ID_клиента == App.Customer.ID_клиента)
                        .ToListAsync();
                    MyOrders = new ObservableCollection<Запись_на_услугу>(types);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void LoadServicesAsync()
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    List<Услуга> types = await entities.Услуга.ToListAsync();
                    Services = new ObservableCollection<Услуга>(types);
                    CurrentOrder.Услуга = Services.First();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnConfirmOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    if (CurrentOrder.Услуга != null)
                    {
                        CurrentOrder.ID_услуги = CurrentOrder.Услуга.ID_услуги;
                        CurrentOrder.Услуга = null;
                    }

                    CurrentOrder.ID_клиента = App.Customer.ID_клиента;
                    entities.Entry(CurrentOrder).State = EntityState.Added;
                    entities.SaveChanges();

                    GoBack();

                    MessageBox.Show("Вы записаны на услугу!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GoBack()
        {
            DealWithUsWindow makeOrderWindow = new DealWithUsWindow();
            makeOrderWindow.Show();
            Close();
        }

        private void OnTimeLoaded(object sender, RoutedEventArgs e)
        {
            (sender as TimePicker).SelectedTime = DateTime.Now;
        }

        private void OnGoBack(object sender, RoutedEventArgs e)
        {
            GoBack();
        }
    }
}
