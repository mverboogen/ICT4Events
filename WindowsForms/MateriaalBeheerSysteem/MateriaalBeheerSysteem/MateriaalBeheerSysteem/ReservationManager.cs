using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaalBeheerSysteem
{
    public class ReservationManager
    {

        public List<Reservation> reservationList = new List<Reservation>();

        public void AddReservation(Reservation reservation)
        {
            foreach(Reservation selectedReservation in reservationList)
            {
                if(selectedReservation.ID == reservation.ID)
                {
                    throw new UsedIDException("Reservation ID " + reservation.ID + " is already used, no reservation was added");
                }
            }

            reservationList.Add(reservation);
        }

        public void RemoveReservation(Reservation reservation)
        {
            int index;

            index = reservationList.IndexOf(reservation);
            if (index != -1)
            {
                reservationList.Remove(reservation);
            }
            else
            {
                throw new UnkownIDException("Reservation ID " + reservation.ID + " was not found, no reservation was deleted");
            }
        }

        public void EditReservation(Reservation reservation)
        {
            int index;

            index = reservationList.IndexOf(reservation);
            if (index != -1)
            {
                reservationList[index] = reservation;
            }
            else
            {
                throw new UnkownIDException("Reservation ID " + reservation.ID + " was not found, no reservation was edited");
            }
        }

        public Reservation GetReservation(int id)
        {
            foreach (Reservation reservation in reservationList)
            {
                if(reservation.ID == id)
                {
                    return reservation;
                }
            }

            return null;
        }

        public Reservation SearchReservationByVisitor(Visitor visitor)
        {
            if (visitor.VisitorReservation != null)
            {
                return visitor.VisitorReservation;
            }
            else
            {
                throw new NoReservationException("This visitor has no reservation");
            }
        }

        public List<Reservation> GetAllCheckedInReservations()
        {
            List<Reservation> CheckedInList = new List<Reservation>();

            foreach(Reservation reservation in reservationList)
            {
                if(reservation.CheckinDate != null)
                {
                    CheckedInList.Add(reservation);
                }
            }

            return CheckedInList;
        }

        public List<Reservation> GetAllCheckedOutReservations()
        {
            List<Reservation> CheckedOutList = new List<Reservation>();

            foreach (Reservation reservation in reservationList)
            {
                if (reservation.DepartDate != null)
                {
                    CheckedOutList.Add(reservation);
                }
            }

            return CheckedOutList;
        }

        public List<Reservation> GetAllAbsentReservations()
        {
            List<Reservation> AbsentList = new List<Reservation>();

            foreach (Reservation reservation in reservationList)
            {
                if (reservation.CheckinDate == null)
                {
                    AbsentList.Add(reservation);
                }
            }

            return AbsentList;
        }
    }
}
