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
        public int AddReservation(Reservation reservation)
        {
            try
            {
                efReservationReporistories.Insert(reservation);
                return 1;
            }
            catch 
            {

                return -1;
            }
           
        }

        public int DeleteReservation(Reservation reservation)
        {
            try
            {
                if (reservation.Id != 0) //null check
                {
                    efReservationReporistories.Delete(reservation);
                }
                return 1;
            }
            catch 
            {

                return -1;
            }
           
        }

        public List<Reservation> GetAllReservations()
        {
            return efReservationReporistories.GetListAll();
        }

        public Reservation GetReservationById(int id)
        {
            return efReservationReporistories.GetById(id); 
        }

        public int UpdateReservation(Reservation reservation)
        {
            try
            {
                if (reservation.Id != 0) //null check
                {
                    efReservationReporistories.Update(reservation);
                }
                return 1;
            }
            catch 
            {
                return -1;
                
            }
           
        }
    }
}
