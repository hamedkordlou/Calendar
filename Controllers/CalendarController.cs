using System.Collections.Generic;
using System.Threading.Tasks;
using Calendar.Core;
using Calendar.Core.Models;
using Calendar.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    [Route("/api/calendar")]
    public class CalendarController : Controller
    {
        private readonly ICalendarRepository repository;
        public CalendarController(ICalendarRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult GetMonthes()
        {
            return Ok(repository.GetMonthes());
        }
        [HttpGet("{id}")]
        public IActionResult GetAppointments(int id)
        {
            return Ok(repository.GetAppointments(id));
        }
    }
}