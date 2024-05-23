using System;
namespace MSB.UI.Controls
{
    /// <summary>
    /// Specifies which message dialog button that a user clicks. <see cref="DialogResult"/>
    /// is returned by the <see cref="MessageDialog.Show()"/> method.
    /// </summary>
    public enum DialogResult
    {
        /// <summary>
        /// The dialog returns no result.
        /// </summary>
        None = 0,

        /// <summary>
        /// The result value of the dialog is OK.
        /// </summary>
        OK = 1,

        /// <summary>
        /// The result value of the dialog is Cancel.
        /// </summary>
        Cancel = 2,

        /// <summary>
        /// The result value of the dialog is Yes.
        /// </summary>
        Yes = 6,

        /// <summary>
        /// The result value of the dialog is No.
        /// </summary>
        No = 7
    }
}
