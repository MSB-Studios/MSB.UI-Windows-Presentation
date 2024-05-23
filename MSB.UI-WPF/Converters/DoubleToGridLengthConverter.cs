using System.Globalization;
using System.Windows.Data;
using System.Windows;
using System;

namespace MSB.Converters
{
    /// <summary>
    /// Represents the converter that converts <see cref="Double"/> to and from <see cref="GridLength"/> value. 
    /// </summary>
    public sealed class DoubleToGridLengthConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double db)
                return new GridLength(db);

            return new GridLength(0d);
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is GridLength gl)
                return gl.Value;

            return 0d;
        }
    }
}
