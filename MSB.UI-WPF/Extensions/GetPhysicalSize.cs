using System.Windows.Media;
using System.Windows;

namespace MSB.Extensions
{
    internal static class FrameworkElementExtensions
    {
        internal static Size GetPhysicalSize(this FrameworkElement element)
        {
            var source = PresentationSource.FromVisual(element);

            var transformToDevice = source is null
                ? Matrix.Identity
                : source.CompositionTarget.TransformToDevice;

            var width = element.ActualWidth * transformToDevice.M11;
            var height = element.ActualHeight * transformToDevice.M22;

            return new Size(width, height);
        }
    }
}
