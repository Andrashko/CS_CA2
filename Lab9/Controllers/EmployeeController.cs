using Microsoft.AspNetCore.Mvc;
using Lab9.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lab9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeRepositoryAsync _repo = new EmployeeRepositoryAsync(new AppDbContext());
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await _repo.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult< Employee>> Get(int id)
        {

            var employee = await _repo.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<Employee> Post([FromBody] Employee value)
        {
            return await _repo.Create(value);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, [FromBody] Employee value)
        {
            var employee = await _repo.Update(id, value);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Delete(int id)
        {
            var employee = await _repo.Delete(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

       
    }
}
