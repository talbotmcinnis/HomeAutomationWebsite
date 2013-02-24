using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _804ManchesterHomeControl.ViewModels
{
    public class ChooseActivityViewModel
    {
        private Dictionary<Int32, String> _activities;

        public ChooseActivityViewModel()
        {
            _activities = new Dictionary<Int32, string>();
        }

        public String RoomName
        { get; set; }

        public void AddActivity(Int32 ActivityId, String ActivityName)
        {
            _activities.Add(ActivityId, ActivityName);
        }

        public Dictionary<Int32, String> Activities
        {
            get { return _activities; }
        }
    }
}