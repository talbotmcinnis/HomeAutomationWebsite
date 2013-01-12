using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _804ManchesterHomeControl.Models
{
    public class HomeActivities
    {
        public enum Room
        {
            LivingRoom,
            Kitchen,
            HomeTheater,
            BasementFireplace,
            MasterBedroom,
            Basement
        }

        public enum Activity
        {
            Watch,
            Listen
        }

        public class HomeActivity
        {
            public HomeActivity(String description, Room room, Activity activity)
            {
                Description = description;
                Room = room;
                Activity = activity;
                Actions = new List<MyDeviceDatabase.Action>();
            }

            public HomeActivity(String description, Room room, Activity activity, MyDeviceDatabase.Action action) :
                this(description, room, activity)
            {
                Actions.Add(action);
            }

            public HomeActivity(String description, Room room, Activity activity, IEnumerable<MyDeviceDatabase.Action> actions):
                this(description, room, activity)
            {
                Actions.AddRange(actions);
            }

            public String Description { get; set; }
            public Room Room { get; set; }
            public Activity Activity { get; set; }

            public List<MyDeviceDatabase.Action> Actions;
        }

        private static List<HomeActivity> _Activities = null;

        public static List<HomeActivity> GetHomeActivities()
        {
            if (_Activities == null)
            {
                // Initially populate activities
                _Activities = new List<HomeActivity>();

                _Activities.Add(new HomeActivity(
                    "Watch HTPC in the living room",
                    Room.LivingRoom,
                    Activity.Watch,
                    new MyDeviceDatabase.Action() { SerialCommand = MyDeviceDatabase.GetSerialCommand(MyDeviceDatabase.Device.HDMI44Matrix, "B1") }
                    ));

                _Activities.Add(new HomeActivity(
                    "Watch AppleTV in the living room",
                    Room.LivingRoom,
                    Activity.Watch,
                    new MyDeviceDatabase.Action() { SerialCommand = MyDeviceDatabase.GetSerialCommand(MyDeviceDatabase.Device.HDMI44Matrix, "B2") }
                    ));

                _Activities.Add(new HomeActivity(
                    "Watch HTPC in the basement",
                    Room.Basement,
                    Activity.Watch,
                    new List<MyDeviceDatabase.Action>{
                        new MyDeviceDatabase.Action() { SerialCommand = MyDeviceDatabase.GetSerialCommand(MyDeviceDatabase.Device.OptomaHD66, "On") },
                        new MyDeviceDatabase.Action() { SerialCommand = MyDeviceDatabase.GetSerialCommand(MyDeviceDatabase.Device.HDMI44Matrix, "A1") }
                    }));
                _Activities.Add(new HomeActivity(
                    "Watch AppleTV in the basement",
                    Room.Basement,
                    Activity.Watch,
                    new List<MyDeviceDatabase.Action>{
                        new MyDeviceDatabase.Action() { SerialCommand = MyDeviceDatabase.GetSerialCommand(MyDeviceDatabase.Device.OptomaHD66, "On") },
                        new MyDeviceDatabase.Action() { SerialCommand = MyDeviceDatabase.GetSerialCommand(MyDeviceDatabase.Device.HDMI44Matrix, "A2") }
                    }));
                _Activities.Add(new HomeActivity(
                    "Leave the basement",
                    Room.Basement,
                    Activity.Watch,
                    new List<MyDeviceDatabase.Action>{
                        new MyDeviceDatabase.Action() { SerialCommand = MyDeviceDatabase.GetSerialCommand(MyDeviceDatabase.Device.OptomaHD66, "Off") }
                    }));

            }
            return _Activities;
        }
    }
}