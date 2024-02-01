using Livraria.Models.Domain;

namespace Livraria.Repositories.Abstract
{
    public interface IGeneroServices
    {
        bool Add(Genero model);
        bool Update(Genero model);
        bool Delete(int id);
        Genero FindById(int id);
        IEnumerable<Genero> GetAll();
    }
}
