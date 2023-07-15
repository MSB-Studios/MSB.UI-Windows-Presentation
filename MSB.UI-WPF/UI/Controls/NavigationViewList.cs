using System.Windows.Controls;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a control that displays menu items in a NavigationView control.
    /// </summary>
    public sealed class NavigationViewList : ListBox
    {
        /// <summary>
        /// Initializes a new instance of the NavigationViewList class.
        /// </summary>
        public NavigationViewList()
        {
            this.DefaultStyleKey = typeof(NavigationViewList);
        }
    }
}
