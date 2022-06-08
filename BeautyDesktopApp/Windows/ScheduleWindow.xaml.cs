using BeautyDesktopApp.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BeautyDesktopApp.Windows
{
    /// <summary>
    /// Interaction logic for ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        public ScheduleWindow()
        {
            InitializeComponent();
            GenerateColumns();
            GenerateDays();
        }

        private void GenerateDays()
        {
            List<List<string>> timesOfDays = new List<List<string>>();
            for (TimeSpan currentTime = TimeSpan.FromHours(10);
                    currentTime < TimeSpan.FromHours(24);
                    currentTime += TimeSpan.FromHours(1))
            {
                List<string> timeSpans = new List<string>();
                for (int i = 0; i < 7; i++)
                {
                    string isWorkString;
                    if (CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(DateTime.Now.AddDays(i)) == DayOfWeek.Sunday)
                    {
                        isWorkString = "выходной";
                    }
                    else if (CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(DateTime.Now.AddDays(i)) == DayOfWeek.Saturday)
                    {
                        if (currentTime.Hours < 20 && currentTime.Hours >= 10)
                        {
                            isWorkString = "работает";
                        }
                        else
                        {
                            isWorkString = "закрыт";
                        }
                    }
                    else
                    {
                        if (currentTime.Hours < 21 && currentTime.Hours >= 10)
                        {
                            isWorkString = "работает";
                        }
                        else
                        {
                            isWorkString = "закрыт";
                        }
                    }
                    timeSpans.Add($"{currentTime:hh\\:mm} - {currentTime.Add(TimeSpan.FromHours(1)):hh\\:mm}: " + isWorkString);
                }
                timesOfDays.Add(timeSpans);
            }
            ScheduleGrid.ItemsSource = timesOfDays;
        }

        private void GenerateColumns()
        {
            for (int i = 0; i < 7; i++)
            {
                FrameworkElementFactory headerFactory = new FrameworkElementFactory(typeof(DayControl));
                headerFactory.SetValue(DayControl.TextProperty, DateTime.Now.AddDays(i).ToString("MMMM dd"));
                var headerTemplate = new DataTemplate
                {
                    VisualTree = headerFactory
                };

                FrameworkElementFactory cellFactory = new FrameworkElementFactory(typeof(DayControl));
                cellFactory.SetValue(DayControl.TextProperty, new Binding($"[{i}]"));
                var cellTemplate = new DataTemplate
                {
                    VisualTree = cellFactory,
                };

                ScheduleGrid.Columns.Add(new DataGridTemplateColumn
                {
                    HeaderTemplate = headerTemplate,
                    CellTemplate = cellTemplate,
                });
            }
        }

        private void GoToMainPageWindow(object sender, RoutedEventArgs e)
        {
            MainPageWindow mainPageWindow = new MainPageWindow();
            mainPageWindow.Show();
            Close();
        }
    }
}
