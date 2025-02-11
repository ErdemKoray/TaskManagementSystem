using TaskManagement.Models;

namespace TaskManagement.Business
{
    public interface IProjectTaskService
    {
        Task<Response> AddProjectTaskAsync(int ProjectId , ProjectTaskCreateDto dto);
        Task<Response> UpdateProjectTaskAsync(int Id, ProjectTaskUpdateDto dto);
        Task<Response> DeleteProjectTaskAsync(int Id);
        Task<Response> GetProjectTaskByIdAsync(int Id);
        Task<Response> GetAllProjectTasksAsync();
    }
}