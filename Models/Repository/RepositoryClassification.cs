namespace OnTime.Models.Repository
{
    public class RepositoryClassification: IRepositoryClassification
    {
        private readonly OnTimeAppointmentsDbContext _context;

        public RepositoryClassification(OnTimeAppointmentsDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get all Classification Objects
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Classification> GetAll()
        {
            return _context.Classifications.Distinct().OrderBy(x => x.Id).ToList();
        }
    }
}
