using Southwind.Repositories;
using Southwind.UnitOfWork;

namespace Southwind.DataAccess
{
    public class SouthWindUnitOfWork : IUnitOfWork
    {
        public SouthWindUnitOfWork(string connectionString)
        {
            Customer = new CustomerRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set; }
    }
}
