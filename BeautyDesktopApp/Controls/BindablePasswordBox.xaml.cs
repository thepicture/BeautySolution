using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BeautyDesktopApp.Controls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {


        public bool IsShouldFocus
        {
            get { return (bool)GetValue(IsShouldFocusProperty); }
            set { SetValue(IsShouldFocusProperty, value); }
        }

        public static readonly DependencyProperty IsShouldFocusProperty =
            DependencyProperty.Register("IsShouldFocus", typeof(bool), typeof(BindablePasswordBox), new PropertyMetadata(default));


        public ControlTemplate ErrorTemplate
        {
            get { return (ControlTemplate)GetValue(ErrorTemplateProperty); }
            set { SetValue(ErrorTemplateProperty, value); }
        }

        public static readonly DependencyProperty ErrorTemplateProperty =
            DependencyProperty.Register("ErrorTemplate",
                                        typeof(ControlTemplate),
                                        typeof(BindablePasswordBox),
                                        new PropertyMetadata(default, OnErrorTemplateChanged));

        private static void OnErrorTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            BindablePasswordBox bindablePasswordBox = (BindablePasswordBox)d;
            bindablePasswordBox.SetValue(Validation.ErrorTemplateProperty, e.NewValue);
        }

        public string BindableText
        {
            get { return (string)GetValue(BindableTextProperty); }
            set { SetValue(BindableTextProperty, value); }
        }

        public static readonly DependencyProperty BindableTextProperty =
            DependencyProperty.Register("BindableText",
                                        typeof(string),
                                        typeof(BindablePasswordBox),
                                        new FrameworkPropertyMetadata(default(string),
                                                                      FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            BindableText = (sender as PasswordBox).Password;
        }

        private void OnPasswordLoaded(object sender, RoutedEventArgs e)
        {
            BindablePassword.Password = BindableText;
            if (IsShouldFocus)
            {
                Keyboard.Focus(BindablePassword);
            }
        }
    }
}
