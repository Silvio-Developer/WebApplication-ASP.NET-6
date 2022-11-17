using Persistencia.Models;

namespace Persistencia.Controllers
{
    public class ClienteController
    {
      private CrudDAO CrudDAO = new CrudDAO();
        public bool Insert(Cliente cliente)
        {
            return CrudDAO.Insert(cliente);
        }
        public List<Cliente> GetAll()
        {
            return CrudDAO.GetAll();
        }
    }
}
