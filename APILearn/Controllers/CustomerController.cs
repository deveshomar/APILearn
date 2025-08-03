using APILearn.Service;
using EntityLibray.Modal;
using Microsoft.AspNetCore.Mvc;

namespace APILearn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _service;
       

        public CustomerController(CustomerService service)
        {
            _service = service;
        }

        // GET: api/employees
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _service.GetAll();
            return Ok(employees);
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _service.GetById(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
        // POST: api/employees
        [HttpPost]
        public IActionResult Create([FromBody] Customer cust)
        {
            _service.Add(cust);
            return CreatedAtAction(nameof(Get), new { id = cust.id }, cust);
        }

    }
}
