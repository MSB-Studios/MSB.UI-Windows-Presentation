using System.Windows.Controls;
using System.Windows;
using MSB.UI.Controls;

namespace DN.Testing.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnShowTeachingTipButtonClick(object sender, RoutedEventArgs e)
        {
            TT.Title = "Hello, World!";
            TT.Description = "Welcome to .NET";
            TT.PreferredPlacement = TeachingTipPlacementMode.Top;
            TT.VerticalOffset = 32;
            TT.IsOpen = true;
        }

        private void OnShowMessageDialogButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome to .NET", "Hello, World!");
            new MessageDialog()
            {
                Title = "Hello, World!",
                Message = "Welcome to .NET"
            }.Show();
        }
    }
}