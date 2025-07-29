using APILearn.Service;
using EntityLibray.Modal;
using Microsoft.AspNetCore.Mvc;

namespace APILearn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
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
        public IActionResult Create([FromBody] Employee employee)
        {
            _service.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        // PUT: api/employees/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
                return BadRequest("ID mismatch");

            var success = _service.Update(employee);
            if (!success)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/employees/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _service.Delete(id);
            if (!success)
                return NotFound();

            return NoContent();
        }

    }
}
