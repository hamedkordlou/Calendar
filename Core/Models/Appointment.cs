using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Calendar.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Person Organizer { get; set; }
        public ICollection<Person> Attendees { get; set; }

        public Appointment()
        {
            Attendees = new Collection<Person>();
        }
    }
}