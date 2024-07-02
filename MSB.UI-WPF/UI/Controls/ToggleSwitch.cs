using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a control that can be switched between two states.
    /// </summary>
    [TemplatePart(Name = "PART_CheckBox", Type = typeof(CheckBox))]
    public sealed class ToggleSwitch : Control
    {
        private CheckBox _checkBox;

        /// <summary>
        /// Initializes a new instance of the 'ToggleSwitch' class.
        /// </summary>
        public ToggleSwitch()
        {
            this.DefaultStyleKey = typeof(ToggleSwitch);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the content to be displayed when the ToggleSwitch is in the "On" state.
        /// <para>The default value is **<see langword="null"/>**.</para>
        /// </summary>
        public string OnContent
        {
            get => (string)GetValue(OnContentProperty);
            set => SetValue(OnContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the content to be displayed when the ToggleSwitch is in the "Off" state.
        /// <para>The default value is **<see langword="null"/>**.</para>
        /// </summary>
        public string OffContent
        {
            get => (string)GetValue(OffContentProperty);
            set => SetValue(OffContentProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the ToggleSwitch is in the "On" state.
        /// <para>The default value is **<see langword="false"/>**.</para>
        /// </summary>
        public bool IsOn
        {
            get => (bool)GetValue(IsOnProperty);
            set => SetValue(IsOnProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the OnContent dependency property.
        /// </summary>
        public static readonly DependencyProperty OnContentProperty =
                DependencyProperty.Register(nameof(OnContent), typeof(object), typeof(ToggleSwitch), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the OffContent dependency property.
        /// </summary>
        public static readonly DependencyProperty OffContentProperty =
                DependencyProperty.Register(nameof(OffContent), typeof(object), typeof(ToggleSwitch), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the IsOn dependency property.
        /// </summary>
        public static readonly DependencyProperty IsOnProperty= 
                DependencyProperty.Register(nameof(IsOn), typeof(bool), typeof(ToggleSwitch), new PropertyMetadata(false, IsOnChanged_Callback));

        #endregion

        #region Callbacks

        private static void IsOnChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is ToggleSwitch @switch)
            {
                @switch.UpdateVisualState();
                @switch.Toggled?.Invoke(@switch, new RoutedEventArgs());
            }
        }

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this._checkBox != null)
            {
                this._checkBox.Checked -= OnCheckBoxChecked;
                this._checkBox.Unchecked -= OnCheckBoxUnchecked;
            }

            this._checkBox = (CheckBox)GetTemplateChild("PART_CheckBox");

            if (this._checkBox != null)
            {
                this._checkBox.Checked += OnCheckBoxChecked;
                this._checkBox.Unchecked += OnCheckBoxUnchecked;
            }

            this.UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            if (this._checkBox != null)
                VisualStateManager.GoToState(this._checkBox, this.IsOn ? "Checked" : "Unckecked", true);
        }

        private void OnCheckBoxChecked(object sender, RoutedEventArgs e)
        {
            this.IsOn = true;
        }

        private void OnCheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            this.IsOn = false;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when "On"/"Off" state changes for this ToggleSwitch.
        /// </summary>
        public event TypedEventHandler<object, RoutedEventArgs> Toggled;

        #endregion
    }
}
