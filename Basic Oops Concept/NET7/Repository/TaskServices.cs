namespace NET7.Repository
{
    public class TaskServices: ITransientServices, ISingletonServices, IScopedServies
    {
        Guid id;
        public TaskServices()
        {
            id= Guid.NewGuid();
        }
        public Guid GetTaskId()
        {
            return id;
        }
    }
}
