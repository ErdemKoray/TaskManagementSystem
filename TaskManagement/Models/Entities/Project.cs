namespace TaskManagement.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }  
        public DateTime StartDate { get; set; }  
        public DateTime? EndDate { get; set; }   
        public ProjectStatus Status { get; set; }  
        public ICollection<Task> Tasks { get; set; }  
        public ICollection<Employee> Employees { get; set; }  
        public int? Budget { get; set; }  
    }
}