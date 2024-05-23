using System.Windows.Controls;
using System.Windows;
using NF.Testing.Views;
using MSB.UI;

namespace NF.Testing
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

            if (this.MainWindow == null)
            {
                var window = new AeroWindow()
                {
                    ExtendViewIntoTitleBar = true,
                    Title = ".NET Framework Testing",
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
