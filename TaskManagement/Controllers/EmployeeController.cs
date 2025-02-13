using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        
        [HttpGet]
        public async Task<ActionResult<Response>> GetEmployeesAsync(){
            var Result = await employeeService.GetAllEmployeeAsync();
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetEmployeeByIdAsync(int id){
            var Result = await employeeService.GetEmployeeByIdAsync(id);
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }
        [HttpPost]
        public async Task<ActionResult<Response>> AddEmployeeAsync(EmployeeCreateDto dto){
            var Result = await employeeService.AddEmployeeAsync(dto);
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> UpdateEmployeeAsync(int id, EmployeeUpdateDto dto){
            var Result = await employeeService.UpdateEmployeeAsync(id, dto);
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteEmployeeAsync(int id){
            var Result = await employeeService.DeleteEmployeeAsync(id);
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }       
    }
}