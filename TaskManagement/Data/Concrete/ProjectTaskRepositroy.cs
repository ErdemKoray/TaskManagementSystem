using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class ProjectTaskRepositroy : BaseRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepositroy(DataContext dataContext) : base(dataContext)
        {
        }
    }
}