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
    public class RoomManager : IRoomService
    {
        GenericRepositories<Room> efRoomReporistories;
        public RoomManager()
        {
            efRoomReporistories = new GenericRepositories<Room>();
        }
        public List<Room> GetAllReservations()
        {
            return efRoomReporistories.GetListAll();
        }

        public Room GetReservationById(int id)
        {
            return efRoomReporistories.GetById(id); 
        }

        public int UpdateRoom(Room room)
        {
            try
            {
                if (room.Id != 0) //null check
                {
                    efRoomReporistories.Update(room);
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
