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
    /// Логика взаимодействия для MainPageWindow.xaml
    /// </summary>
    public partial class MainPageWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Отзыв> Reviews { get; set; }

        public MainPageWindow()
        {
            InitializeComponent();
            LoadReviewsAsync();
        }

        private async void LoadReviewsAsync()
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    List<Отзыв> reviews = await entities.Отзыв
                        .OrderByDescending(r => r.Дата_публикации)
                        .Include(r => r.Клиент)
                        .ToListAsync();
                    Reviews = new ObservableCollection<Отзыв>(reviews);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Uslugi_Click(object sender, RoutedEventArgs e)
        {
            ServicesWindow servicesWindow = new ServicesWindow();
            servicesWindow.Show();
            Close();
        }

        private void Svyaz_Click(object sender, RoutedEventArgs e)
        {
            DealWithUsWindow dealWithUsWindow = new DealWithUsWindow();
            dealWithUsWindow.Show();
            Close();
        }

        private void Onas_Click(object sender, RoutedEventArgs e)
        {
            AboutUsWindow aboutUsWindow = new AboutUsWindow();
            aboutUsWindow.Show();
            Close();
        }

        private void GoToMasterWorksWindow(object sender, RoutedEventArgs e)
        {
            MasterWorksWindow masterWorksWindow = new MasterWorksWindow();
            masterWorksWindow.Show();
            Close();
        }

        private void OnPostReview(object sender, RoutedEventArgs e)
        {
            if (App.Worker != null)
            {
                MessageBox.Show("Только клиенты могут оставлять отзывы, вы сотрудник!");
                return;
            }
            if (string.IsNullOrWhiteSpace(ReviewText.Text))
            {
                MessageBox.Show("Введите отзыв");
            }
            else
            {
                try
                {
                    using (BeautyBaseEntities entities = new BeautyBaseEntities())
                    {
                        entities.Отзыв.Add(new Отзыв
                        {
                            ID_клиента = App.Customer.ID_клиента,
                            Текст = ReviewText.Text,
                            Дата_публикации = DateTime.Now
                        });
                        entities.SaveChanges();
                    }
                    MessageBox.Show("Отзыв опубликован!");
                    ReviewText.Text = string.Empty;
                    LoadReviewsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void GoToCustomersWindow(object sender, RoutedEventArgs e)
        {
            CustomersWindow customersWindow = new CustomersWindow();
            customersWindow.Show();
            Close();
        }

        private void GoToScheduleWindow(object sender, RoutedEventArgs e)
        {
            ScheduleWindow scheduleWindow = new ScheduleWindow();
            scheduleWindow.Show();
            Close();
        }
    }
}
