using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IRoomService
    {
        void UpdateRoom(Room room);
        List<Room> GetAllReservations();
        Room GetReservationById(int id);
    }
}
