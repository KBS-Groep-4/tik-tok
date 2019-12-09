﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RoeiJeRot.Database.Database;
using RoeiJeRot.Logic.Services;
using RoeiJeRot.View.Wpf.Logic;
using RoeiJeRot.View.Wpf.ViewModels;

namespace RoeiJeRot.View.Wpf.Views.Windows
{
    /// <summary>
    ///     Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : UserControl
    {
        private readonly IBoatService _boatService;
        private readonly IReservationService _reservationService;

        public ReservationWindow(IBoatService boatService, IReservationService reservationService)
        {
            _boatService = boatService;
            _reservationService = reservationService;

            InitializeComponent();

            When.SelectedDate = DateTime.Today;

            UpdateAvailableList();
        }

        private void OnLogoutButtonClick(object sender, RoutedEventArgs e)
        {
            var rs = InstanceCreator.Instance.CreateInstance<LoginWindow>();
            rs.Show();
        }

        public ObservableCollection<BoatTypeViewModel> ObservableAvailableTypes { get; set; }

        public void ReservButtonOnClick(object sender, RoutedEventArgs args)
        {
            TimeSpan time;
            if (TimeSpan.TryParse(Time.Text, out time))
            {
                if (time.TotalHours > 24)
                    return;

                int durationInt;
                if (int.TryParse(Duration.Text, out durationInt))
                {
                    var duration = TimeSpan.FromMinutes(durationInt);

                    var selectedItemObject = AvailableBoats.SelectedItem;
                    if (selectedItemObject == null)
                    {
                        MessageBox.Show("Geen boot geselecteerd");
                        return;
                    }

                    var selectedType = (BoatTypeViewModel) selectedItemObject;

                    if (When.SelectedDate.HasValue)
                    {
                        bool result = _reservationService.PlaceReservation(selectedType.Id, 1, When.SelectedDate.Value + time,
                            duration);
                        if (result) MessageBox.Show("Reservering geplaatst");
                        else MessageBox.Show("Reservatie niet geplaatst");

                        UpdateAvailableList();
                    }
                }
            }
        }

        public void OnReservationDetailChange(object sender, EventArgs args)
        {
            UpdateAvailableList();
        }

        public void UpdateAvailableList()
        {
            TimeSpan time;
            int durationInt;

            if (TimeSpan.TryParse(Time.Text, out time) && Duration != null &&
                int.TryParse(Duration.Text, out durationInt) &&
                When.SelectedDate.HasValue)
            {
                var boats = _boatService.GetAvailableBoats(When.SelectedDate.Value + time,
                    TimeSpan.FromMinutes(durationInt));
                var availableTypes = new List<BoatType>();

                foreach (var boat in boats)
                {
                    var alreadyIn = false;
                    foreach (var type in availableTypes)
                        if (type.Id == boat.BoatTypeId)
                            alreadyIn = true;

                    if (!alreadyIn) availableTypes.Add(boat.BoatType);
                }

                ObservableAvailableTypes = new ObservableCollection<BoatTypeViewModel>(availableTypes
                    .Select(type => new BoatTypeViewModel
                    {
                        Id = type.Id,
                        Name = type.Name,
                        PossiblePassengers = type.PossiblePassengers,
                        RequiredLevel = type.RequiredLevel
                    })
                    .ToList());

                AvailableBoats.ItemsSource = ObservableAvailableTypes;
            }
            else if (AvailableBoats != null)
            {
                AvailableBoats.ItemsSource = null;
            }
        }
    }
}