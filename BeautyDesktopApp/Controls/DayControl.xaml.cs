using System.Windows;
using System.Windows.Controls;

namespace BeautyDesktopApp.Controls
{
    /// <summary>
    /// Interaction logic for DayControl.xaml
    /// </summary>
    public partial class DayControl : UserControl
    {


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(DayControl), new PropertyMetadata(default));


        public DayControl()
        {
            InitializeComponent();
        }
    }
}
