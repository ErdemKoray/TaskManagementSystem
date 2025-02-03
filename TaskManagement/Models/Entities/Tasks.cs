namespace TaskManagement.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int AssignedEmployeeId { get; set; }
        public Employee AssignedEmployee { get; set; }
    }

}