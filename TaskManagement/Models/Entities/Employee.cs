namespace TaskManagement.Models
{
    public class Employee
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleType Role { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}