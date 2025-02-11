namespace TaskManagement.Models
{
    public class ProjectTaskUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }

        public int ProjectId { get; set; }

        public int AssignedEmployeeId { get; set; }
    }
}
