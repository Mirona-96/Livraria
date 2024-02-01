using Livraria.Models.Domain;

namespace Livraria.Repositories.Abstract
{
    public interface IBookServices
    {
        bool Add(Livro model);
        bool Update(Livro model);
        bool Delete(int id);
        Livro FindById(int id);
        IEnumerable<Livro> GetAll();
    }
}
