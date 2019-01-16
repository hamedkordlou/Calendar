using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Core;
using Calendar.Core.Models;
using NUnit.Framework;

namespace Calendar.Persistence
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly CalendarContext context;
        public CalendarRepository(CalendarContext context)
        {
            this.context = context;
        }
        public void Add(Month month)
        {
            context.Monthes.Add(month);
        }

        public void Add(Appointment appointment)
        {
            context.Appointments.Add(appointment);
        }

        public void Add(Person person)
        {
            context.People.Add(person);
        }

        public Appointment GetAppointment(int id)
        {
            return context.Appointments.FirstOrDefault(a => a.Id == id);
        }

        public List<Appointment> GetAppointments(int monthId)
        {
            return context.Appointments.Where(a => a.Date.Month == monthId).ToList();
        }

        public List<Month> GetMonthes()
        {
            return context.Monthes;
        }
    }

    [TestFixture]
    class CalendarRepositoryTests
    {
        private CalendarContext _mockContext;
        private CalendarRepository _mockRepository;
        [SetUp]
        public void SetUp()
        {
            _mockContext = new CalendarContext();
            _mockRepository = new CalendarRepository(_mockContext);
        }
        [TestCase(1, 1)]
        [TestCase(12, 12)]
        public void GetMonthes_ThereAreSomeMonthes_ReturnProperCount(int given, int expected)
        {
            for(int i = 1; i <= given; i++)
            {
                _mockContext.Monthes.Add(new Month(){ Id = i, Name = "m" + i.ToString() });
            }
            var cnt = _mockRepository.GetMonthes().Count;
            Assert.That(cnt, Is.EqualTo(expected));
        }
        [Test]
        public void GetAppointment_TheGivenAppointmentExist_ReturnTheAppointment()
        {
            var organizer = new Person(){Id = 1, Fname = "Hamed", Lname = "Kordlou"};
            var attendees = new Collection<Person>()
            {
                new Person() {Id = 2, Fname = "a", Lname = "b"},
                new Person() {Id = 3, Fname = "c", Lname = "d"}
            };
            var appointment = new Appointment()
            {
                Id = 1,
                Description = "Test",
                Date = new System.DateTime(2019, 1, 1),
                Organizer = organizer,
                Attendees = attendees
            };
            _mockRepository.Add(appointment);
            var result = _mockRepository.GetAppointment(1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Organizer.Id, Is.EqualTo(1));
        }
        [Test]
        public void GetAppointment_TheGivenAppointmentDoesNotExist_ReturnTheNUllOrEmpty()
        {
            var organizer = new Person(){Id = 1, Fname = "Hamed", Lname = "Kordlou"};
            var attendees = new Collection<Person>()
            {
                new Person() {Id = 2, Fname = "a", Lname = "b"},
                new Person() {Id = 3, Fname = "c", Lname = "d"}
            };
            var appointment = new Appointment()
            {
                Id = 1,
                Description = "Test",
                Date = new System.DateTime(2019, 1, 1),
                Organizer = organizer,
                Attendees = attendees
            };
            _mockRepository.Add(appointment);
            var result = _mockRepository.GetAppointment(2);
            Assert.That(result, Is.Null.Or.Empty);
        }
        [TestCase(1,1)]
        [TestCase(2,0)]
        [TestCase(3,0)]
        [TestCase(4,1)]
        [TestCase(5,0)]
        public void GetAppointments_GettingTheNumberOfAppointmentsInTheGivenMonth_ReturnCorrectNumber(int monthId, int expected)
        {
            var organizer = new Person(){Id = 1, Fname = "Hamed", Lname = "Kordlou"};
            var attendees = new Collection<Person>()
            {
                new Person() {Id = 2, Fname = "a", Lname = "b"},
                new Person() {Id = 3, Fname = "c", Lname = "d"}
            };
            var appointment = new Appointment()
            {
                Id = 1,
                Description = "Test",
                Date = new System.DateTime(2019, 1, 1),
                Organizer = organizer,
                Attendees = attendees
            };
            _mockRepository.Add(appointment);

            attendees = new Collection<Person>()
            {
                new Person() {Id = 4, Fname = "e", Lname = "f"},
            };
            appointment = new Appointment()
            {
                Id = 4,
                Description = "Test",
                Date = new System.DateTime(2019, 4, 1),
                Organizer = organizer,
                Attendees = attendees
            };
            _mockRepository.Add(appointment);
            var result = _mockRepository.GetAppointments(monthId);
            var cnt = (result == null) ? 0 : result.Count;
            Assert.That(cnt, Is.EqualTo(expected));
        }
        [Test]
        public void GetAppointments_ThereIsNoSuchAppointment_ReturnTheNUllOrEmpty()
        {
            var organizer = new Person(){Id = 1, Fname = "Hamed", Lname = "Kordlou"};
            var attendees = new Collection<Person>()
            {
                new Person() {Id = 2, Fname = "a", Lname = "b"},
                new Person() {Id = 3, Fname = "c", Lname = "d"}
            };
            var appointment = new Appointment()
            {
                Id = 1,
                Description = "Test",
                Date = new System.DateTime(2019, 1, 1),
                Organizer = organizer,
                Attendees = attendees
            };
            _mockRepository.Add(appointment);
            var result = _mockRepository.GetAppointment(2);
            Assert.That(result, Is.Null.Or.Empty);
        }
        [Test]
        public void AddMonth_AddingMonth_ShouldBeAddedCorrectly()
        {
            _mockRepository.Add(new Month(){Id = 1, Name = "Jan"});
            var cnt = _mockContext.Monthes.Count;
            Assert.That(cnt, Is.EqualTo(1));
        }
        [Test]
        public void AddPerson_AddingPerson_ShouldBeAddedCorrectly()
        {
            _mockRepository.Add(new Person(){Id = 1, Fname = "Hamed", Lname = "Kordlou"});
            var cnt = _mockContext.People.Count;
            Assert.That(cnt, Is.EqualTo(1));
        }
        [Test]
        public void AddAppointment_AddingAppointment_ShouldBeAddedCorrectly()
        {
            var organizer = new Person(){Id = 1, Fname = "Hamed", Lname = "Kordlou"};
            var attendees = new Collection<Person>()
            {
                new Person() {Id = 2, Fname = "a", Lname = "b"},
                new Person() {Id = 3, Fname = "c", Lname = "d"}
            };
            var appointment = new Appointment()
            {
                Id = 1,
                Description = "Test",
                Date = new System.DateTime(2019, 1, 1),
                Organizer = organizer,
                Attendees = attendees
            };
            _mockRepository.Add(appointment);
            var cnt = _mockContext.Appointments.Count;
            
            Assert.That(cnt, Is.EqualTo(1));
        }
        
    }
}