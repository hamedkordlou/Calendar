using Calendar.Core;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.Controllers
{
    public class GeneralController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public GeneralController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("/api/general")]
        public IActionResult Initialize()
        {
            unitOfWork.InitialData();
            return Ok();
        }
    }
}