using Livraria.Models.Domain;

namespace Livraria.Repositories.Abstract
{
    public interface IAutorServices
    {
        bool Add(Autor model);
        bool Update(Autor model);
        bool Delete(int id);
        Autor FindById(int id);
        IEnumerable<Autor> GetAll();
    }
}
