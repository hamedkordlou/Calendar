namespace Calendar.Core
{
    public interface IUnitOfWork
    {
         void Complete();
         void InitialData();
    }
}