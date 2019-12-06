﻿using System;
using System.Collections.Generic;
using System.Linq;
using RoeiJeRot.Database.Database;

namespace RoeiJeRot.Logic.Services
{
    public interface IReservationService
    {
        /// <summary>
        ///     Places an new boat reservation on the given date with duration.
        /// </summary>
        bool PlaceReservation(int boatType, int memberId, DateTime reservationDate, TimeSpan duration);

        /// <summary>
        ///     Returns all reservations from the current data
        /// </summary>
        /// <returns>All sailingReservations</returns>
        List<SailingReservation> GetReservations();

        /// <summary>
        ///     Cancels a boat reservation.
        /// </summary>
        /// <param name="reservationId"></param>
        void CancelReservation(int reservationId);

        List<SailingReservation> AllocateBoatReservations(int boatId);
    }

    public class ReservationService : IReservationService
    {
        private readonly IBoatService _boatService;
        private readonly RoeiJeRotDbContext _context;

        public ReservationService(RoeiJeRotDbContext context, IBoatService boatService)
        {
            _context = context;
            _boatService = boatService;
        }


        /// <inheritdoc />
        public bool PlaceReservation(int boatType, int memberId, DateTime reservationDate, TimeSpan duration)
        {
            var availableBoats = _boatService.GetAvailableBoats(reservationDate, duration).Where(boat => boat.BoatTypeId == boatType && boat.Status != (int)BoatState.InService).ToList();

            // Check if there is an available boat
            if (availableBoats.Count > 0)
            {
                SailingBoat boatToReserve = null;

                // Take the boat with most reservations
                var max = int.MinValue;
                foreach (var boat in availableBoats)
                {
                    if(boat.BoatTypeId == boatType)
                        if (boat.SailingReservations.Count >= max)
                            boatToReserve = boat;
                }

                //Create a reservation for this boat
                _context.Reservations.Add(new SailingReservation
                {
                    Date = reservationDate,
                    Duration = duration,
                    ReservedByUserId = memberId,
                    ReservedSailingBoatId = boatToReserve.Id
                });

                _context.SaveChanges();
                return true;
            }

            return false;
        }

        /// <inheritdoc />
        public List<SailingReservation> GetReservations()
        {
            return _context.Reservations.Where(x => x.Date >= DateTime.Now.Date).ToList();
        }

        /// <inheritdoc />
        public void CancelReservation(int reservationId)
        {
            var reservations = _context.Reservations.Where(reserv => reserv.Id == reservationId);
            SailingReservation reservation;
            if (reservations.Any())
            {
                reservation = reservations.First();
                _context.Remove(reservation);
            }
            else throw new Exception("No reservation of this id found");
        }

        /// <summary>
        /// Cancels all future reservations for this boatId and places them on another
        /// </summary>
        /// <param name="boatId"></param>
        /// <returns>A list of reservations that could not be re-allocated</returns>
        public List<SailingReservation> AllocateBoatReservations(int boatId)
        {
            // Get all future reservations that need to be cancelled
            var reservationsToCancel =
                _context.Reservations.Where(reserv => reserv.ReservedSailingBoatId == boatId && reserv.Date > DateTime.Now).ToList();

            // List of boats that could not be allocated
            List<SailingReservation> notReAllocatable = new List<SailingReservation>();

            // Place for each reservation a new reservation, if one could not be placed they are put in not Can
            foreach (SailingReservation reservation in reservationsToCancel)
            {
                int boatType = reservation.ReservedSailingBoat.BoatTypeId;
                int boatUser = reservation.ReservedByUserId;
                DateTime reservationDate = reservation.Date;
                TimeSpan reservationDuration = reservation.Duration;

                if(!PlaceReservation(boatType, boatUser, reservationDate, reservationDuration)) 
                    notReAllocatable.Add(reservation);

                _context.Remove(reservation);
                _context.SaveChanges();
            }

            return notReAllocatable;
        }
    }
}