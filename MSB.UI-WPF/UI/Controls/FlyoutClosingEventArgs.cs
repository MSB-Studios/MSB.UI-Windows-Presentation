using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Provides event data for the <see cref="Flyout.Closing"/> event.
    /// </summary>
    [Obsolete]
    public sealed class FlyoutClosingEventArgs : EventArgs
    {
        internal FlyoutClosingEventArgs()
        {

        }

        /// <summary>
        /// Gets or sets a value that indicates whether the flyout should be closed.
        /// </summary>
        public bool Cancel
        {
            get;
            set;
        }
    }
}
