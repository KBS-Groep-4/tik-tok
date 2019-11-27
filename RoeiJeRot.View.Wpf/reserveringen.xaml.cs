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
    public class ReserveringViewModel
    {
        public int Id { get; set; }
        public string BoatTypeName { get; set; }
        public int Status { get; set; }
        public bool Reserved { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan Duration { get; set; }
    }

    /// <summary>
    /// Interaction logic for reserveringen.xaml
    /// </summary>
    public partial class reserveringen : Window
    {
        public ObservableCollection<ReserveringViewModel> Items { get; set; } = new ObservableCollection<ReserveringViewModel>();

        public reserveringen()
        {
            InitializeComponent();

            // vervang met daata uit data ` IReservationService` 
            Items.Add(new ReserveringViewModel() {Id = 1, BoatTypeName = "Boat Type 1", Status = 2, Reserved = true, Duration = TimeSpan.FromHours(2), ReservationDate = DateTime.Now});
            Items.Add(new ReserveringViewModel() {Id = 2, BoatTypeName = "Boat Type 2", Status = 1, Reserved = true, Duration = TimeSpan.FromHours(2), ReservationDate = DateTime.Now });
            Items.Add(new ReserveringViewModel() {Id = 3, BoatTypeName = "Boat Type 3", Status = 1, Reserved = false, Duration = TimeSpan.FromHours(2), ReservationDate = DateTime.Now });
            Items.Add(new ReserveringViewModel() {Id = 4, BoatTypeName = "Boat Type 4", Status = 2, Reserved = true, Duration = TimeSpan.FromHours(2), ReservationDate = DateTime.Now });
            Items.Add(new ReserveringViewModel() {Id = 5, BoatTypeName = "Boat Type 5", Status = 3, Reserved = false , Duration = TimeSpan.FromHours(2), ReservationDate = DateTime.Now });

            DeviceDataGrid.ItemsSource = Items;
        }
    }
}
