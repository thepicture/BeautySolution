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
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    List<Отзыв> reviews = entities.Отзыв
                        .Include(r => r.Клиент)
                        .ToList();
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
            Window3 Window = new Window3();
            Window.Show();
            Close();
        }

        private void Svyaz_Click(object sender, RoutedEventArgs e)
        {
            Window4 Window = new Window4();
            Window.Show();
            Close();
        }

        private void Onas_Click(object sender, RoutedEventArgs e)
        {
            AboutUsWindow Window = new AboutUsWindow();
            Window.Show();
            Close();
        }

        private void GoToMasterWorksWindow(object sender, RoutedEventArgs e)
        {
            MasterWorksWindow Window = new MasterWorksWindow();
            Window.Show();
            Close();
        }
    }
}
