namespace TaskManagement.Models
{
    public class ProjectUpdateDto
    {
        public string? Name { get; set; }           
        public string? Description { get; set; }    
        public DateTime? StartDate { get; set; }    
        public DateTime? EndDate { get; set; }      
        public ProjectStatus? Status { get; set; }  
        public int? Budget { get; set; }            
       
    }
}
