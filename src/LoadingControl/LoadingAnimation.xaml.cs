using System.Windows;
using System.Windows.Controls;

namespace WpfAutoCompleteTextBoxWithAkka.LoadingControl
{
    /// <summary>
    /// Interaction logic for LoadingAnimation.xaml
    /// </summary>
    public partial class LoadingAnimation : UserControl
    {

        public string LoadingText
        {
            get { return (string)GetValue(LoadingTextProperty); }
            set { SetValue(LoadingTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoadingText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadingTextProperty =
            DependencyProperty.Register("LoadingText", typeof(string), typeof(LoadingAnimation));




        public LoadingAnimation()
        {
            InitializeComponent();
        }
    }
}
