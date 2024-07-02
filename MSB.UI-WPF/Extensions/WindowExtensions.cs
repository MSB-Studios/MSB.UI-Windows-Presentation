using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Reflection;
using System.Drawing;
using System.Windows;

namespace MSB.Extensions
{
    internal static class WindowExtensions
    {
        internal static void GetAssemblyIcon(this Window window)
        {
            try
            {
                var icon = Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly().Location);

                window.Icon = Imaging.CreateBitmapSourceFromHIcon(
                    icon.Handle,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            catch
            {
                return;
            }
        }
    }
}
