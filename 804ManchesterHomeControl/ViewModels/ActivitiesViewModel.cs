using _804ManchesterHomeControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _804ManchesterHomeControl.ViewModels
{
    public class ActivitiesViewModel
    {
        public IEnumerable<SelectListItem> Rooms
        {
            get
            {
                IEnumerable<HomeActivities.Room> distinctRooms = (from a in HomeActivities.GetHomeActivities()
                                                                    select a.Room).Distinct();

                List<SelectListItem> results = new List<SelectListItem>();

                foreach( HomeActivities.Room room in (from a in HomeActivities.GetHomeActivities()
                                                                    select a.Room).Distinct() )
                {
                    results.Add(new SelectListItem() { Value = room.ToString(), Text = room.ToString() });
                }

                return results;
            }
        }

        public HomeActivities.Room SelectedRoom
        { get; set; }
    }
}