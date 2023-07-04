using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Provides event data for the SplitView.PaneClosing event.
    /// </summary>
    public sealed class SplitViewPaneClosingEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets a value that indicates whether the pane closing action should be canceled.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
