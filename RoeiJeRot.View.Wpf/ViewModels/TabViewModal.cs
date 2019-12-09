using System.Collections.ObjectModel;
using System.Windows.Controls;
using RoeiJeRot.View.Wpf.Views.Windows;

namespace RoeiJeRot.View.Wpf.ViewModels
{
    public sealed class TabViewModal
    {
        /// <summary>
        /// The tabs that are shown in the tab view.
        /// </summary>
        public ObservableCollection<ActionTabItem> Tabs { get; set; }

        public TabViewModal()
        {
            Tabs = new ObservableCollection<ActionTabItem>();
        }
    }
}
