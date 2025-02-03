namespace TaskManagement.Data
{
    public class TaskRepositroy : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepositroy(DataContext dataContext) : base(dataContext)
        {
        }
    }
}