﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RoeiJeRot.Database.Database;

namespace RoeiJeRot.Logic.Services
{
    /// <summary>
    /// Interface for logic that retrieves, creates, cancels reservations.
    /// </summary>
    public interface IReservationService
    {
        /// <summary>
        /// Places an boat reservation on a particular date.
        /// </summary>
        /// <param name="boatType"></param>
        /// <param name="memberId"></param>
        /// <param name="reservationDate"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        bool PlaceReservation(int boatType, int memberId, DateTime reservationDate, TimeSpan duration);
        
        /// <summary>
        /// Cancels an boat reservation.
        /// </summary>
        /// <returns>All sailingReservations</returns>
        void CancelReservation(int reservationId);
    }

    public class ReservationService : IReservationService
    { 
        private readonly RoeiJeRotDbContext _context;
        private readonly IBoatService _boatService;

        public ReservationService(RoeiJeRotDbContext context, IBoatService boatService)
        {
            _context = context;
            _boatService = boatService;
        }

      
        public bool PlaceReservation(int boatType, int memberid, DateTime reservationDate, TimeSpan duration)
        {
            var availableBoats = _boatService.GetAvailableBoats(reservationDate, duration, boatType);

            if (availableBoats.Count > 0)
            {
                SailingBoat boatToReserve = null;

                int min = int.MaxValue;
                foreach (var boat in availableBoats)
                    if (boat.SailingReservations.Count < min) boatToReserve = boat;

                _context.Reservations.Add(new SailingReservation()
                {
                    Date = reservationDate,
                    Duration = duration,
                    ReservedByUserId = memberid,
                    ReservedSailingBoatId = boatToReserve.Id
                });

                _context.SaveChanges();
                return true;
            }
            
            return false;
        }

        public List<SailingReservation> GetReservations()
        {
            return _context.Reservations.ToList();
        }

        public void CancelReservation(int reservationId)
        {
            throw new NotImplementedException();
        }
    }
}
