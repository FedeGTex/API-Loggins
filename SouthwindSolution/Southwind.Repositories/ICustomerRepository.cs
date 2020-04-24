using Southwind.Models;
using System.Collections.Generic;

namespace Southwind.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        //Se genera un nuevo método para la paginación de customer
        //Devuelve una lista de Customers
        //param1:Pagina actual param2: num de reg por página
        IEnumerable<Customer> CustomerPageList(int page, int rows);
    }
}
