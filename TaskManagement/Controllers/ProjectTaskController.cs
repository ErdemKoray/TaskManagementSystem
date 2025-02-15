using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTaskController : ControllerBase
    {
       private readonly IProjectTaskService _projectTaskService;
       public ProjectTaskController(IProjectTaskService projectTaskService)
       {
           _projectTaskService = projectTaskService;
       }


        [HttpGet]
        public async Task<ActionResult<Response>> GetAllProjectTasksAsync()
        {
            var result = await _projectTaskService.GetAllProjectTasksAsync();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetProjectTaskByIdAsync(int id)
        {
            var result = await _projectTaskService.GetProjectTaskByIdAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> AddProjectTaskAsync( ProjectTaskCreateDto dto)
        {
            var result = await _projectTaskService.AddProjectTaskAsync( dto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> UpdateProjectTaskAsync(int id, ProjectTaskUpdateDto dto)
        {
            var result = await _projectTaskService.UpdateProjectTaskAsync(id, dto);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteProjectTaskAsync(int id)
        {
            var result = await _projectTaskService.DeleteProjectTaskAsync(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result.Message);
        }
    }
}
