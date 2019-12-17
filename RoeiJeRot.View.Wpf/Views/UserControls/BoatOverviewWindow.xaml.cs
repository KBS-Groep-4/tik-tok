using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RoeiJeRot.Logic.Services;
using RoeiJeRot.View.Wpf.Logic;
using RoeiJeRot.View.Wpf.ViewModels;
using RoeiJeRot.View.Wpf.Views.Windows;

namespace RoeiJeRot.View.Wpf.Views.UserControls
{
    /// <summary>
    ///     Interaction logic for ReservationOverviewScreen.xaml
    /// </summary>
    public partial class BoatOverviewWindow : CustomUserControl
    {
        private readonly WindowManager _windowManager;

        public BoatOverviewWindow(IBoatService boatService, WindowManager windowManager)
        {
            _windowManager = windowManager;
            InitializeComponent();
            SetBoatData(boatService);
            DeviceDataGrid.ItemsSource = Items;
        }

        public ObservableCollection<BoatTypeViewModel> Items { get; set; } =
            new ObservableCollection<BoatTypeViewModel>();

        // Set data for the reservations view.
        public void SetBoatData(IBoatService boatService)
        {
            var boats = boatService.GetAllBoats()
                .Select(r => new BoatTypeViewModel
                {
                    Id = r.Id,
                    PossiblePassengers = r.BoatType.PossiblePassengers,
                    RequiredLevel = r.BoatType.RequiredLevel,
                    Name = r.BoatType.Name,
                    HasCommanderSeat = r.BoatType.HasCommanderSeat
                }).ToList();
            foreach (var boat in boats) Items.Add(boat);
            
        }
        public void OnClose()
        {
        }
    }
}
