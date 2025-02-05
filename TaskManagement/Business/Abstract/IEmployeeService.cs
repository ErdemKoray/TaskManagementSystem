using TaskManagement.Models;

namespace TaskManagement.Business
{
    public interface IEmployeeService
    {
        Task<Response> GetAllEmployeeAsync();
        Task<Response> GetEmployeeByIdAsync(int Id);
        Task<Response> AddEmployeeAsync(EmployeeCreateDto dto);
        Task<Response> UpdateEmployeeAsync(int Id, EmployeeUpdateDto dto);
        Task<Response> DeleteEmployeeAsync(int Id);
    }
}