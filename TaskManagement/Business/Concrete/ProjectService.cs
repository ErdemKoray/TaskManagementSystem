using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Business
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<Response> AddProjectAsync(ProjectCreateDto dto)
        {
            var Response = new Response();
            try
            {
                var Project = new Project()
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    StartDate = dto.StartDate ?? default(DateTime),
                    EndDate = dto.EndDate,
                    Status = dto.Status ?? default(ProjectStatus),
                    Budget = dto.Budget
                };
                await _projectRepository.AddAsync(Project);
                await _projectRepository.SaveAsync();
                Response.Data = Project;
                Response.Message = "Project Added Successfully";
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while adding project : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> DeleteProjectAsync(int Id)
        {
            var Response = new Response();
            try
            {
                var Project = await _projectRepository.GetByIdAsync(Id);
                if (Project == null)
                {
                    Response.Success = false;
                    Response.Message = "Project not found";
                    return Response;
                }
                await _projectRepository.DeleteAsync(Project);
                await _projectRepository.SaveAsync();
                Response.Message = "Project Deleted Successfully";
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while deleting project : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> GetAllProjectsAsync()
        {
            var Response = new Response();
            try
            {
                var Projects = await _projectRepository.GetAllAsync();
                if (Projects == null)
                {
                    Response.Message = "Projects not found";
                    Response.Success = false;
                }
                else
                {
                    Response.Data = Projects;
                    Response.Message = "Projects retrieved successfully.";
                }

            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while retrieving projects : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> GetProjectByIdAsync(int Id)
        {
            var Response = new Response();
            try
            {
                var Project = await _projectRepository.GetByIdAsync(Id);
                if (Project == null)
                {
                    Response.Message = "Project not found";
                    Response.Success = false;
                }
                else
                {
                    Response.Data = Project;
                    Response.Message = "Project retrieved successfully.";
                }

            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while retrieving project : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> UpdateProjectAsync(int Id, ProjectUpdateDto dto)
        {
            var Response = new Response();
            try
            {
                var Project = await _projectRepository.GetByIdAsync(Id);
                if (Project == null)
                {
                    Response.Message = "Project not found.";
                    Response.Success = false;
                }
                else
                {
                Project.Name = dto.Name ?? default(string);
                Project.Description = dto.Description ?? default(string);
                Project.StartDate = dto.StartDate ?? default(DateTime);
                Project.EndDate = dto.EndDate ?? default(DateTime);
                Project.Status = dto.Status ?? default(ProjectStatus);
                Project.Budget = dto.Budget ?? default(int);
                await _projectRepository.UpdateAsync(Project);
                await _projectRepository.SaveAsync();
                Response.Message = "Project Updated Successfully";
                }
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while updating project : {ex.Message}";
            }
            return Response;
        }
    }
}