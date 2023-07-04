using System.Runtime.CompilerServices;
using System.Windows;
using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a resource dictionary that contains the styles for the custom controls.
    /// </summary>
    public sealed partial class XamlControlResources : ResourceDictionary
    {
        /// <summary>
        /// Initializes a new instance of the 'XamlControlResources' class.
        /// </summary>
        public XamlControlResources()
        {
            this.InitializeComponent();
            
            if (Application.Current is RichApplication app)
                app.ThemeChanged += OnAppThemeChanged;
        }

        #region Properties

        /// <summary>
        /// Gets or sets an uri that contains the styles or brushes for the light theme.
        /// </summary>
        public Uri LightSource
        {
            get => lightSource;
            set => SetValue(ref lightSource, value);
        }

        /// <summary>
        /// Gets or sets an uri that contains the styles or brushes for the dark theme.
        /// </summary>
        public Uri DarkSource
        {
            get => darkSource;
            set => SetValue(ref darkSource, value);
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

        private void OnAppThemeChanged(object sender, EventArgs e)
        {
            UpdateThemeDictionary();
        }

        /// <summary>
        /// Invoked inmediately after a property value changes.
        /// </summary>
        /// <param name="name">Name of the property that changed.</param>
        private void OnPropertyChanged(string name)
        {
            if (name is nameof(LightSource) || name is nameof(DarkSource))
                UpdateThemeDictionary();
        }

        private void UpdateThemeDictionary()
        {
            var app = (RichApplication)Application.Current;

            if (app.Theme is ApplicationTheme.Light)
                this.MergedDictionaries[1].Source = LightSource;
            else
                this.MergedDictionaries[1].Source = DarkSource;
        }

        #endregion

        Uri lightSource, darkSource;

        // this.Source = new System.Uri("pack://application:,,,/MSB.UI-WPF;component/Assets/XamlControlResources.xaml");
    }
}
