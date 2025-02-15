using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Business
{
    public class ProjectTaskService : IProjectTaskService
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly IProjectRepository _projectRepository;
        public ProjectTaskService(IProjectTaskRepository projectTaskRepository , IProjectRepository projectRepository)
        {
            _projectTaskRepository = projectTaskRepository;
            _projectRepository = projectRepository;
        }

        public async Task<Response> AddProjectTaskAsync(ProjectTaskCreateDto dto)
        {
            var Response = new Response();
            try
            {
                var newTask = new ProjectTask()
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Status = dto.Status,
                    Priority = dto.Priority,
                    ProjectId = dto.ProjectId,
                    AssignedEmployeeId = dto.AssignedEmployeeId
                };
                await _projectTaskRepository.AddAsync(newTask);
                await _projectTaskRepository.SaveAsync();
                Response.Data = newTask;
                Response.Message = "Task Added Successfully";
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while adding task : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> DeleteProjectTaskAsync(int Id)
        {
            var Response = new Response();
            try
            {
                var task = await _projectTaskRepository.GetByIdAsync(Id);
                if (task == null)
                {
                    Response.Success = false;
                    Response.Message = "Task not found";
                    return Response;
                }
                await _projectTaskRepository.DeleteAsync(task);
                await _projectTaskRepository.SaveAsync();
                Response.Message = "Task Deleted Successfully";
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while deleting task : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> GetAllProjectTasksAsync()
        {
            var Response = new Response();
            try
            {
                var tasks = await _projectTaskRepository.GetAllAsync();
                Response.Data = tasks;
                Response.Message = "Tasks Listed Successfully";
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while listing tasks : {ex.Message}";
            }
            return Response;    
        }

        public async Task<Response> GetProjectTaskByIdAsync(int Id)
        {
            var Response = new Response();
            try
            {
                var task = await _projectTaskRepository.GetByIdAsync(Id);
                if (task == null)
                {
                    Response.Success = false;
                    Response.Message = "Task not found";
                    return Response;
                }
                Response.Data = task;
                Response.Message = "Task retrieved successfully";
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while retrieving task : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> UpdateProjectTaskAsync(int Id, ProjectTaskUpdateDto dto)
        {
            var Response = new Response();
            try
            {
                var task = await _projectTaskRepository.GetByIdAsync(Id);
                if (task == null)
                {
                    Response.Success = false;
                    Response.Message = "Task not found";
                    return Response;
                }
                task.Title = dto.Title;
                task.Description = dto.Description;
                task.Status = dto.Status;
                task.Priority = dto.Priority;
                task.ProjectId = dto.ProjectId;
                task.AssignedEmployeeId = dto.AssignedEmployeeId;
                await _projectTaskRepository.UpdateAsync(task);
                await _projectTaskRepository.SaveAsync();
                Response.Data = task;
                Response.Message = "Task Updated Successfully";
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while updating task : {ex.Message}";
            }
            return Response;
        }
    }
}