using System.Runtime.CompilerServices;
using System.Windows;
using System;

namespace MSB.UI
{
    /// <summary>
    /// Represents an extended App class.
    /// </summary>
    public class RichApplication : Application
    {
        /// <summary>
        /// 
        /// </summary>
        public RichApplication()
        {
            
        }

        #region Properties

        /// <summary>
        /// Gets or sets the theme used by the app.
        /// </summary>
        public ApplicationTheme Theme
        {
            get => theme;
            set => SetValue(ref theme, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks if a property already matches the desired value.
        /// Sets the property and notifies listeners if necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="field">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="name">Name of the property used to notify listeners.</param>
        /// <returns>**<see langword="true"/>** if the value was changed, otherwise **<see langword="false"/>**.</returns>
        private bool SetValue<T>(ref T field, T value, [CallerMemberName] string name = "")
        {
            if (!Equals(field, value))
            {
                field = value;
                OnPropertyChanged(name);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Invoked inmediately after a property value changes.
        /// </summary>
        /// <param name="name">Name of the property that changed.</param>
        private void OnPropertyChanged(string name)
        {
            switch (name)
            {
                case "Theme":
                    this.ThemeChanged?.Invoke(this, EventArgs.Empty);

                    break;
            }
        }

        #endregion

        #region Events

        /// <inheritdoc/>
        public event TypedEventHandler<object, EventArgs> ThemeChanged;

        #endregion

        ApplicationTheme theme;
    }

    /// <summary>
    /// Define constants about the theme used by the app.
    /// </summary>
    public enum ApplicationTheme
    {
        /// <summary>
        /// The app uses the light assets.
        /// </summary>
        Light,

        /// <summary>
        /// The app uses the dark assets.
        /// </summary>
        Dark
    }
}
