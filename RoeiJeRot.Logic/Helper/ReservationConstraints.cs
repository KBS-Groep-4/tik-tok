using System;
using System.Collections.Generic;
using System.Text;
using RoeiJeRot.Logic.Services;

namespace RoeiJeRot.Logic.Helper
{
    public class ReservationConstraintsMsg
    {
        public bool IsValid { get; private set; }
        public string Reason { get; private set; }

        public ReservationConstraintsMsg(bool isValid, string reason)
        {
            IsValid = isValid;
            Reason = reason;
        }
    }

    public static class ReservationConstraints
    {
        public static ReservationConstraintsMsg isValid(DateTime date, TimeSpan duration, IReservationService reservationService, int accId)
        {
            if (date < DateTime.Now || date + duration < DateTime.Now) return new ReservationConstraintsMsg(false, "Reservatie is in het verleden");
            if (duration > TimeSpan.FromHours(2)) return new ReservationConstraintsMsg(false, "Reservatie is te lang (max 2 uur)");
            if (reservationService.GetFutureReservations(accId).Count >= 2) return new ReservationConstraintsMsg(false, "U heeft al teveel reservaties geplaatst voor de toekomst");

            //TODO Check if it's daytime


            else return new ReservationConstraintsMsg(true, "All is fine");
        }
    }
}
