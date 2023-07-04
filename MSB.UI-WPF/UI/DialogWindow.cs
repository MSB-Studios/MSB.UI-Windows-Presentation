using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using MSB.UI.Controls;

namespace MSB.UI
{
    internal class DialogWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the 'DialogWindow' class.
        /// </summary>
        internal DialogWindow()
        {
            this.DefaultStyleKey = typeof(DialogWindow);
        }

        #region Properties

        /// <summary>
        /// Gets the dialog result value, which is the value that is returned from the <see cref="MessageDialog.Show()"/> method.
        /// </summary>
        public MessageDialogResult Result
        {
            get => result;
        }

        #endregion

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (titleBarRect is not null)
                titleBarRect.MouseDown -= TitleBar_MouseDown;

            if (btnOK is not null)
                btnOK.Click -= OnOKButtonClick;
            if (btnYes is not null)
                btnYes.Click -= OnYesButtonClick;
            if (btnNo is not null)
                btnNo.Click -= OnNoButtonClick;
            if (btnCancel is not null)
                btnCancel.Click -= OnCancelButtonClick;

            titleBarRect = (Rectangle)GetTemplateChild("TitleBarRect");

            btnOK = (Button)GetTemplateChild("BtnOK");
            btnYes = (Button)GetTemplateChild("BtnYes");
            btnNo = (Button)GetTemplateChild("BtnNo");
            btnCancel = (Button)GetTemplateChild("BtnCancel");

            if (titleBarRect is not null)
                titleBarRect.MouseDown += TitleBar_MouseDown;

            if (btnOK is not null)
                btnOK.Click += OnOKButtonClick;
            if (btnYes is not null)
                btnYes.Click += OnYesButtonClick;
            if (btnNo is not null)
                btnNo.Click += OnNoButtonClick;
            if (btnCancel is not null)
                btnCancel.Click += OnCancelButtonClick;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!this.DialogResult.HasValue)
                e.Cancel = true;
        }

        private void OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            result = MessageDialogResult.OK;

            this.DialogResult = true;
        }

        private void OnYesButtonClick(object sender, RoutedEventArgs e)
        {
            result = MessageDialogResult.Yes;

            this.DialogResult = true;
        }

        private void OnNoButtonClick(object sender, RoutedEventArgs e)
        {
            result = MessageDialogResult.No;

            this.DialogResult = true;
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            result = MessageDialogResult.Cancel;

            this.DialogResult = true;
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
                this.DragMove();
        }

        #endregion

        Rectangle titleBarRect;
        Button btnOK, btnCancel, btnYes, btnNo;
        MessageDialogResult result;
    }
}
