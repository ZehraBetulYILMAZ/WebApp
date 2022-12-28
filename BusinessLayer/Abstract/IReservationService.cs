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
        int AddReservation(Reservation reservation);
        int DeleteReservation(Reservation reservation);
        int UpdateReservation(Reservation reservation);
        List<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
    }
}
