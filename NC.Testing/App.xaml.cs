using System.Windows.Controls;
using System.Windows;
using NC.Testing.Views;
using MSB.UI;

namespace NC.Testing
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    sealed partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var rootFrame = new Frame()
            {
                Content = new MainPage(),
            };

            if (this.MainWindow is null)
            {
                var window = new AeroWindow()
                {
                    ExtendViewIntoTitleBar = true,
                    Title = ".NET Core Testing",
                    MinHeight = 400,
                    MinWidth = 600,
                    Height = 0,
                    Width = 0,
                    Content = rootFrame,
                };

                this.MainWindow = window;
            }

            this.MainWindow.Show();
        }
    }
}
