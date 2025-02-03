
using TaskManagement.Models;

namespace TaskManagement.Data
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }

}