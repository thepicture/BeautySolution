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
    /// Логика взаимодействия для MasterWorksWindow.xaml
    /// </summary>
    public partial class MasterWorksWindow : Window, INotifyPropertyChanged
    {
        private string serviceSearchText;
        private Работник selectedMaster;
        private Тип_услуги selectedServiceType;

        public ObservableCollection<Услуга> Services { get; set; }
        public ObservableCollection<Тип_услуги> ServiceTypes { get; set; }
        public ObservableCollection<Работник> Masters { get; set; }

        public Тип_услуги SelectedServiceType
        {
            get => selectedServiceType;
            set
            {
                selectedServiceType = value;
                FilterServicesAsync();
            }
        }
        public Работник SelectedMaster
        {
            get => selectedMaster;
            set
            {
                selectedMaster = value;
                FilterServicesAsync();
            }
        }

        public string ServiceSearchText
        {
            get => serviceSearchText;
            set
            {
                serviceSearchText = value;
                FilterServicesAsync();
            }
        }

        public MasterWorksWindow()
        {
            InitializeComponent();
            LoadServiceTypesAsync();
            LoadMastersAsync();
            FilterServicesAsync();
        }

        private async void LoadMastersAsync()
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    List<Работник> masters = await entities.Работник.ToListAsync();
                    masters.Insert(0, new Работник { ФИО = "Все мастеры" });
                    Masters = new ObservableCollection<Работник>(masters);
                    SelectedMaster = Masters.First();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void LoadServiceTypesAsync()
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    List<Тип_услуги> types = await entities.Тип_услуги.ToListAsync();
                    types.Insert(0, new Тип_услуги { Название = "Любой тип" });
                    ServiceTypes = new ObservableCollection<Тип_услуги>(types);
                    SelectedServiceType = ServiceTypes.First();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void FilterServicesAsync()
        {
            try
            {
                using (BeautyBaseEntities entities = new BeautyBaseEntities())
                {
                    List<Услуга> services = await entities.Услуга
                        .Include(s => s.Тип_услуги)
                        .Include(s => s.Работник)
                        .ToListAsync();
                    if (SelectedServiceType != null && SelectedServiceType.ID_типа_услуги > 0)
                    {
                        services = services
                            .Where(s => s.ID_типа_услуги == SelectedServiceType.ID_типа_услуги)
                            .ToList();
                    }
                    if (SelectedMaster != null && SelectedMaster.ID_раб > 0)
                    {
                        services = services
                            .Where(s => s.ID_работника == SelectedMaster.ID_раб)
                            .ToList();
                    }
                    if (!string.IsNullOrWhiteSpace(ServiceSearchText))
                    {
                        services = services
                            .Where(s =>
                            {
                                return s.Название.IndexOf(ServiceSearchText,
                                                          StringComparison.OrdinalIgnoreCase) != -1;
                            })
                            .ToList();
                    }
                    Services = new ObservableCollection<Услуга>(services);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GoToAboutUsWindow(object sender, RoutedEventArgs e)
        {
            AboutUsWindow Window = new AboutUsWindow();
            Window.Show();
            Close();
        }

        private void GoToMainPageWindow(object sender, RoutedEventArgs e)
        {
            MainPageWindow Window = new MainPageWindow();
            Window.Show();
            Close();
        }
    }
}
