using Domain.Request;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace SOA_P2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_employee.GetAll());
        }
        [HttpPost]
        public IActionResult Create([FromBody] RequestPostCreateEmployee employee)
        {
            return Ok(_employee.CreateEmployee(employee));
        }
        [HttpPatch]
        public IActionResult Update([FromBody] RequestPatchUpdateEmployee employee)
        {
            return Ok(_employee.UpdateEmployee(employee));
        }
		[HttpDelete]
		public IActionResult Delete([FromBody] string idEmployee)
		{
			return Ok(_employee.DeleteEmployee(idEmployee));
		}
	}
}
