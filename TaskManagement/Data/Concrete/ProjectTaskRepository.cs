using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class ProjectTaskRepository : BaseRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}