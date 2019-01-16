using System.Collections.Generic;
using Calendar.Core;
using Calendar.Core.Models;

namespace Calendar.Persistence
{
    public class CalendarContext
    {
        public List<Month> Monthes { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Person> People { get; set; }

        public CalendarContext()
        {
            Monthes = new List<Month>();
            Appointments = new List<Appointment>();
            People = new List<Person>();
        }
    }
}