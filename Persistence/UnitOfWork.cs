using System.Collections.ObjectModel;
using Calendar.Core;
using Calendar.Core.Models;

namespace Calendar.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CalendarContext context;
        public UnitOfWork(CalendarContext context)
        {
            this.context = context;
        }
        public void Complete()
        {

        }
        public void InitialData()
        {
            var month1 = new Month() {Id = 1, Name = "Jan"};
            var month2 = new Month() {Id = 2, Name = "Feb"};
            var month3 = new Month() {Id = 3, Name = "Mar"};
            var month4 = new Month() {Id = 4, Name = "Apr"};
            var month5 = new Month() {Id = 5, Name = "May"};
            var month6 = new Month() {Id = 6, Name = "Jun"};
            var month7 = new Month() {Id = 7, Name = "Jul"};
            var month8 = new Month() {Id = 8, Name = "Aug"};
            var month9 = new Month() {Id = 9, Name = "Sep"};
            var month10 = new Month() {Id = 10, Name = "Oct"};
            var month11 = new Month() {Id = 11, Name = "Nov"};
            var month12 = new Month() {Id = 12, Name = "Dec"};

            var person1 = new Person() {Id = 1, Fname = "Hamed", Lname = "Kordlou"};
            var person2 = new Person() {Id = 2, Fname = "F1", Lname = "L2"};
            var person3 = new Person() {Id = 3, Fname = "F2", Lname = "L3"};
            var person4 = new Person() {Id = 4, Fname = "F3", Lname = "L4"};

            var attendees1 = new Collection<Person>()
            {
                person2, person3
            };
            var attendees2 = new Collection<Person>()
            {
                person4
            };
            var attendees3 = new Collection<Person>()
            {
                person1, person3
            };

            var appointment1 = new Appointment()
            {
                Id = 1,
                Description = "Team Meeting",
                Date = new System.DateTime(2019, 1, 1),
                Organizer = person1,
                Attendees = attendees1
            };
            var appointment2 = new Appointment()
            {
                Id = 2,
                Description = "Lunch with Joe",
                Date = new System.DateTime(2019, 1, 1),
                Organizer = person2,
                Attendees = attendees2
            };
            var appointment3 = new Appointment()
            {
                Id = 3,
                Description = "Project Meeting",
                Date = new System.DateTime(2019, 4, 1),
                Organizer = person2,
                Attendees = attendees3
            };

            context.Monthes.AddRange(new [] {month1, month2, month3, month4, month5, month6, month7, month8, month9, month10, month11, month12});
            context.People.AddRange(new [] {person1, person2, person3, person4});
            context.Appointments.AddRange(new [] {appointment1, appointment2, appointment3});
        }
    }
}