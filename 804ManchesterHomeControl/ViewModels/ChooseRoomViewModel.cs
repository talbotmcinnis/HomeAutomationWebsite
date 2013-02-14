using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _804ManchesterHomeControl.ViewModels
{
    public class ChooseRoomViewModel
    {
        private Dictionary<Int32, String> _rooms;

        public ChooseRoomViewModel()
        {
            _rooms = new Dictionary<Int32, string>();
        }

        public void AddRoom(Int32 RoomId, String RoomName)
        {
            _rooms.Add(RoomId, RoomName);
        }

        public Dictionary<Int32, String> Rooms
        {
            get { return _rooms; }
        }
    }
}