using TaskManagement.Models;

namespace TaskManagement.Business
{
    public interface IProjectService 
    {
        Task<Response> GetAllProjectsAsync();
        Task<Response> GetProjectByIdAsync(int Id);
        Task<Response> AddProjectAsync(ProjectCreateDto dto);
        Task<Response> UpdateProjectAsync(int Id , ProjectUpdateDto dto);
        Task<Response> DeleteProjectAsync(int Id);
    }
}