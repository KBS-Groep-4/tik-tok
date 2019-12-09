using System.Windows.Controls;

namespace RoeiJeRot.View.Wpf.ViewModels
{
    /// <summary>
    /// Represents a tab item from the tab panel.
    /// </summary>
    public sealed class ActionTabItem
    {
        /// <summary>
        /// The display name of the tab item.
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// The user control that will be shown in the tab.
        /// </summary>
        public UserControl Content { get; set; }
    }
}
