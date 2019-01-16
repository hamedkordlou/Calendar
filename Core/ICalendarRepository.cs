using System.Collections.Generic;
using System.Threading.Tasks;
using Calendar.Core.Models;

namespace Calendar.Core
{
    public interface ICalendarRepository
    {
         List<Month> GetMonthes();
         Appointment GetAppointment(int id);
         List<Appointment> GetAppointments(int id);
        //  Task<Appointment> GetDetail(int id);
         void Add(Month month);
         void Add(Appointment appointment);
         void Add(Person person);
         
    }
}