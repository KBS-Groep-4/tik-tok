using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RoeiJeRot.Database.Database;
using RoeiJeRot.Logic.Services;
using RoeiJeRot.View.Wpf.Logic;
using RoeiJeRot.View.Wpf.ViewModels;
using RoeiJeRot.View.Wpf.Views.Windows;

namespace RoeiJeRot.View.Wpf.Views.UserControls
{
    public class MessageArgs : EventArgs
    {
        public string Message { get; set; }
        public string Error { get; set; }
        public MessageArgs(string message, string error)
        {
            Message = message;
            Error = error;
        }
    }
    /// <summary>
    ///     Interaction logic for ReservationOverviewScreen.xaml
    /// </summary>
    public partial class ReservationOverviewScreen : CustomUserControl
    {
        private readonly WindowManager _windowManager;

        private IReservationService _reservationService;
        public event EventHandler<MessageArgs> StatusMessageUpdate;

        public ReservationOverviewScreen(IReservationService reservationService, WindowManager windowManager)
        {
            _windowManager = windowManager;
            InitializeComponent();
            SetReservationData(reservationService);
            DeviceDataGrid.ItemsSource = Items;
        }

        public ObservableCollection<ReservationViewModel> Items { get; set; } =
            new ObservableCollection<ReservationViewModel>();

        // Set data for the reservations view.
        public void SetReservationData(IReservationService reservationService)
        {
            _reservationService = reservationService;
            var reservations = reservationService.GetReservations()
                .Select(r => new ReservationViewModel
                {
                    Id = r.Id,
                    ReservationDate = r.Date.ToString("g"),
                    Duration = r.Duration.ToString(@"hh\:mm"),
                    ReservedByUserId = r.ReservedBy.Username,
                    ReservedBoatId = r.ReservedSailingBoatId
                }).ToList();

            foreach (var reservation in reservations) Items.Add(reservation);
        }

        private void OnCancelClick(object sender, RoutedEventArgs e)
        {
            foreach (var data in DeviceDataGrid.SelectedItems)
            {
                _reservationService.CancelReservation(((ReservationViewModel)data).Id);
            }

            StatusMessageUpdate?.Invoke(this, new MessageArgs("Reservering(en) verwijderd.", "cancel"));
        }
    }
}