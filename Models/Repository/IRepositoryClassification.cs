namespace OnTime.Models.Repository
{
    public interface IRepositoryClassification
    {
        IEnumerable<Classification> GetAll();
    }
}
