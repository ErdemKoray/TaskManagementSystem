namespace TaskManagement.Models
{
    public class EmployeeCreateDto
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; }   
        public int Age { get; set; }           
        public string Email { get; set; }      
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }   
        public string? City { get; set; }      
        public string? Country { get; set; }    
        public DateTime HireDate { get; set; } 
        public decimal Salary { get; set; }    
        public string Department { get; set; } 
        public RoleType Role { get; set; }     
        public List<string> Skills { get; set; } 
        public int YearsOfExperience { get; set; } 
    }
}
