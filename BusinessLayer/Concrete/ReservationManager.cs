using BusinessLogicLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
   public class ReservationManager : IReservationService
    {
        GenericRepositories<Reservation> efReservationReporistories;
        public ReservationManager()
        {
            efReservationReporistories = new GenericRepositories<Reservation>();
        }
        public void AddReservation(Reservation reservation)
        {
            efReservationReporistories.Insert(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            if (reservation.Id != 0) //null check
            {
                efReservationReporistories.Delete(reservation);
            }
        }

        public List<Reservation> GetAllReservations()
        {
            return efReservationReporistories.GetListAll();
        }

        public Reservation GetReservationById(int id)
        {
            return efReservationReporistories.GetById(id); //exeption at
        }

        public void UpdateReservation(Reservation reservation)
        {
            if (reservation.Id != 0) //null check
            {
                efReservationReporistories.Update(reservation);
            }
        }
    }
}
