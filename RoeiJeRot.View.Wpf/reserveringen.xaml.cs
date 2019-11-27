using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RoeiJeRot.View.Wpf
{
    public class ViewModel
    {
        public int BoatTypeId { get; set; }
        public int Status { get; set; }
        public bool Reserved { get; set; }
    }

    /// <summary>
    /// Interaction logic for reserveringen.xaml
    /// </summary>
    public partial class reserveringen : Window
    {
        public ObservableCollection<ViewModel> Items { get; set; }

        public reserveringen()
        {
            InitializeComponent();

            Items.Add(new ViewModel() { BoatTypeId = 1, Status = 2, Reserved = true});

            DeviceDataGrid.ItemsSource = Items;
        }
    }
}
