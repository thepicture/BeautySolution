using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeautyDesktopApp.Controls
{
    /// <summary>
    /// Interaction logic for CommonBindablePasswordBox.xaml
    /// </summary>
    public partial class CommonBindablePasswordBox : UserControl
    {

        public bool IsShouldFocus
        {
            get { return (bool)GetValue(IsShouldFocusProperty); }
            set { SetValue(IsShouldFocusProperty, value); }
        }

        public static readonly DependencyProperty IsShouldFocusProperty =
            DependencyProperty.Register("IsShouldFocus", typeof(bool), typeof(CommonBindablePasswordBox), new PropertyMetadata(default));


        public ControlTemplate ErrorTemplate
        {
            get { return (ControlTemplate)GetValue(ErrorTemplateProperty); }
            set { SetValue(ErrorTemplateProperty, value); }
        }

        public static readonly DependencyProperty ErrorTemplateProperty =
            DependencyProperty.Register("ErrorTemplate",
                                        typeof(ControlTemplate),
                                        typeof(CommonBindablePasswordBox),
                                        new PropertyMetadata(default, OnErrorTemplateChanged));

        private static void OnErrorTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            CommonBindablePasswordBox bindablePasswordBox = (CommonBindablePasswordBox)d;
            bindablePasswordBox.BindablePassword.SetValue(Validation.ErrorTemplateProperty, e.NewValue);
        }

        public string BindableText
        {
            get { return (string)GetValue(BindableTextProperty); }
            set { SetValue(BindableTextProperty, value); }
        }

        public static readonly DependencyProperty BindableTextProperty =
            DependencyProperty.Register("BindableText",
                                        typeof(string),
                                        typeof(CommonBindablePasswordBox),
                                        new FrameworkPropertyMetadata(default(string),
                                                                      FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public CommonBindablePasswordBox()
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
