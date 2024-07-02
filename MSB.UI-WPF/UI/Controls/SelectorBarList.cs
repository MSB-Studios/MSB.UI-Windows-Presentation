using System.Windows.Controls;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a list of items that can be selected by the user.
    /// </summary>
    public sealed class SelectorBarList : ListBox
    {
        /// <summary>
        /// Initializes a new instance of the 'SelectorBarList' class.
        /// </summary>
        public SelectorBarList()
        {
            this.DefaultStyleKey = typeof(SelectorBarList);
        }
    }
}
