namespace MSB.UI.Controls
{
    /// <summary>
    /// Defines constants that specify how the pane is shown in a NavigationView.
    /// </summary>
    public enum NavigationViewDisplayMode
    {
        /// <summary>
        /// The pane automatically shows and hides as needed.
        /// </summary>
        Auto,

        /// <summary>
        /// Only the menu button remains fixed. The pane shows and hides as needed.
        /// </summary>
        Minimal,

        /// <summary>
        /// The pane always shows as a narrow sliver which can be opened to full width.
        /// </summary>
        Compact,

        /// <summary>
        /// The pane stays open alongside the content.
        /// </summary>
        Expanded
    }
}

