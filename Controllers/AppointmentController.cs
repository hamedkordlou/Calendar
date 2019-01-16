using Calendar.Core;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    [Route("/api/appointment")]
    public class AppointmentController : Controller
    {
        private readonly ICalendarRepository repository;
        public AppointmentController(ICalendarRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet("{id}")]
        public IActionResult GetAppointment(int id)
        {
            return Ok(repository.GetAppointment(id));
        }
    }
}