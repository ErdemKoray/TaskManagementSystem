using Microsoft.AspNetCore.Mvc;
using TaskManagement.Business;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;
        public ProjectController(IProjectService _projectService)
        {
            projectService = _projectService;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetProjectsAsync(){
            var Result = await projectService.GetAllProjectsAsync();
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetProjectByIdAsync(int id){
            var Result = await projectService.GetProjectByIdAsync(id);
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }
        [HttpPost]
        public async Task<ActionResult<Response>> AddProjectAsync(ProjectCreateDto dto){
            var Result = await projectService.AddProjectAsync(dto);
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> UpdateProjectAsync(int id, ProjectUpdateDto dto){
            var Result = await projectService.UpdateProjectAsync(id, dto);
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteProjectAsync(int id){
            var Result = await projectService.DeleteProjectAsync(id);
            if(Result.Success)
                return Ok(Result);
            else
                return BadRequest(Result.Message);
        }
    }
}