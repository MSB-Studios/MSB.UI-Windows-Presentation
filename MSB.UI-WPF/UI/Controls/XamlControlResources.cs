using System.Runtime.CompilerServices;
using System.Windows.Media;
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

            if (Application.Current is not RichApplication app)
                return;

            app.ThemeChanged += OnAppThemeChanged;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the color used as accent color.
        /// </summary>
        public Color AccentColor
        {
            get => accentColor;
            set => SetValue(ref accentColor, value);
        }

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
            switch (name)
            {
                case "AccentColor":
                    UpdateAccentColor();

                    break;
                default:
                    UpdateThemeDictionary();

                    break;
            }
        }

        private void UpdateAccentColor()
        {
            this["ApplicationAccentColor"] = this.AccentColor;

            // lighter...
            this["ApplicationAccentColorLight1"] = GetLighterColor(this.AccentColor, 26, 8, 13);
            this["ApplicationAccentColorLight2"] = GetLighterColor(this.AccentColor, 52, 18, 26);
            this["ApplicationAccentColorLight3"] = GetLighterColor(this.AccentColor, 78, 24, 39);

            // darker...
            this["ApplicationAccentColorDark1"] = GetDarkerColor(this.AccentColor, 26, 8, 13);
            this["ApplicationAccentColorDark2"] = GetDarkerColor(this.AccentColor, 52, 18, 26);
            this["ApplicationAccentColorDark3"] = GetDarkerColor(this.AccentColor, 78, 24, 39);
        }

        private void UpdateThemeDictionary()
        {
            if (Application.Current is not RichApplication app)
                return;

            if (app.Theme is ApplicationTheme.Light)
                this.MergedDictionaries[1].Source = LightSource;
            else
                this.MergedDictionaries[1].Source = DarkSource;
        }

        static Color GetLighterColor(Color color, int r, int b, int g)
        {
            int lr = CheckMinMax(color.R + r);
            int lg = CheckMinMax(color.G + g);
            int lb = CheckMinMax(color.B + b);

            return (Color)ColorConverter.ConvertFromString(
                $"#{HexFromInteger(lr)}{HexFromInteger(lg)}{HexFromInteger(lb)}");
        }

        static Color GetDarkerColor(Color color, int r, int g, int b)
        {
            int dr = CheckMinMax(color.R - r);
            int dg = CheckMinMax(color.G - g);
            int db = CheckMinMax(color.B - b);

            return (Color)ColorConverter.ConvertFromString(
                $"#{HexFromInteger(dr)}{HexFromInteger(dg)}{HexFromInteger(db)}");
        }

        static int CheckMinMax(int value)
        {
            if (value > 255)
                return 255;
            else if (value < 0)
                return 0;

            return value;
        }

        static string HexFromInteger(int value)
        {
            var hex = value.ToString("X");

            if (hex.Length < 2)
                return $"0{hex}";

            return hex;
        }

        #endregion

        Color accentColor;
        Uri lightSource, darkSource;

        // this.Source = new System.Uri("pack://application:,,,/MSB.UI-WPF;component/Assets/XamlControlResources.xaml");
    }
}
