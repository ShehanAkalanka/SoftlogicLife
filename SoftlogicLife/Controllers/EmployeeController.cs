using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftlogicLife.Data;
using SoftlogicLife.Models;
using SoftlogicLife.Services.EmployeeService;

namespace SoftlogicLife.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            try
            {
                return Ok(await _employeeService.GetAllEmployees());
            }
            catch (TimeoutException)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, "The database query timed out.");
            }
            catch (Exception ex)
            {
                // Handle all other exceptions (including database-related ones)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Employee>>> GetSingleEmployee(int id)
        {
            try
            {
                return Ok(await _employeeService.GetSingleEmployee(id));
            }
            catch (TimeoutException)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, "The database query timed out.");
            }
            catch (Exception ex)
            {
                // Handle all other exceptions (including database-related ones)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }


        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee request)
        {
            try
            {
                var result = await _employeeService.AddEmployee(request);
                return Ok(result);
            }
            catch (TimeoutException)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, "The database query timed out.");
            }
            catch (Exception ex)
            {
                // Handle all other exceptions (including database-related ones)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Employee>>> UpdateSuperhero(int id, Employee request)
        {
            
            try
            {
                var result = await _employeeService.UpdateEmployee(id, request);
                return Ok(result);
            }
            catch (TimeoutException)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, "The database query timed out.");
            }
            catch (Exception ex)
            {
                // Handle all other exceptions (including database-related ones)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteSuperhero(int id)
        {
            try
            {
                var result = await _employeeService.DeleteEmployee(id);
                return Ok(result);
            }
            catch (TimeoutException)
            {
                return StatusCode(StatusCodes.Status408RequestTimeout, "The database query timed out.");
            }
            catch (Exception ex)
            {
                // Handle all other exceptions (including database-related ones)
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

    }
}
