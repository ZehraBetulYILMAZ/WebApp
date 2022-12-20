using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
  public  interface IReservationService
    {
        void AddReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        void UpdateReservation(Reservation reservation);
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
    }
}
