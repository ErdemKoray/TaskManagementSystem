using System.Net.Http.Headers;
using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }
        public async Task<Response> AddEmployeeAsync(EmployeeCreateDto dto)
        {
            var Response = new Response();
            try
            {
                var Employee = new Employee()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age,
                    Email = dto.Email,
                    PhoneNumber = dto.PhoneNumber,
                    Address = dto.Address,
                    City = dto.City,
                    Country = dto.Country,
                    HireDate = dto.HireDate,
                    Salary = dto.Salary,
                    Department = dto.Department,
                    Role = dto.Role,
                    Skills = dto.Skills,
                    YearsOfExperience = dto.YearsOfExperience
                };
                await employeeRepository.AddAsync(Employee);
                await employeeRepository.SaveAsync();
                Response.Data = Employee;
                Response.Message = "Employee Added Successfully";
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while adding employee : {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> DeleteEmployeeAsync(int Id)
        {
            var Response = new Response();
            try
            {
                var Employee = await employeeRepository.GetByIdAsync(Id);
                if (Employee == null)
                {
                    Response.Message = "Employee not found";
                    Response.Success = false;
                }
                else
                {
                    await employeeRepository.DeleteAsync(Employee);
                    await employeeRepository.SaveAsync();
                }
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while deleting the employee: {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> GetAllEmployeeAsync()
        {
            var Response = new Response();
            try
            {
                var Employees = await employeeRepository.GetAllAsync();
                if (Employees == null)
                {
                    Response.Message = "Employees not found";
                    Response.Success = false;
                }
                else
                {
                    Response.Data = Employees;
                    Response.Message = "Employees retrieved successfully.";
                }

            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while retrieving the employees: {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> GetEmployeeByIdAsync(int Id)
        {
            var Response = new Response();
            try
            {
                var Employee = await employeeRepository.GetByIdAsync(Id);
                if (Employee == null)
                {
                    Response.Message = "Employee not found";
                    Response.Success = false;
                }
                else
                {
                    Response.Data = Employee;
                    Response.Message = "Employee retrieved successfully.";
                }
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while retrieving the employee: {ex.Message}";
            }
            return Response;
        }

        public async Task<Response> UpdateEmployeeAsync(int Id, EmployeeUpdateDto dto)
        {
            var Response = new Response();
            try
            {
                var Employee = await employeeRepository.GetByIdAsync(Id);
                if (Employee == null)
                {
                    Response.Message = "Employee not found.";
                    Response.Success = false;
                }
                else
                {
                    Employee.FirstName = dto.FirstName;
                    Employee.LastName = dto.LastName;
                    Employee.Age = dto.Age;
                    Employee.Email = dto.Email;
                    Employee.PhoneNumber = dto.PhoneNumber;
                    Employee.Address = dto.Address;
                    Employee.City = dto.City;
                    Employee.Country = dto.Country;
                    Employee.HireDate = dto.HireDate;
                    Employee.Salary = dto.Salary;
                    Employee.Department = dto.Department;
                    Employee.Role = dto.Role;
                    Employee.Skills = dto.Skills;
                    Employee.YearsOfExperience = dto.YearsOfExperience;
                }
            }
            catch (Exception ex)
            {
                Response.Success = false;
                Response.Message = $"An error occurred while updating the employee: {ex.Message}";
            }
            return Response;
        }
    }
}