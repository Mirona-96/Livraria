using Livraria.Models.Domain;

namespace Livraria.Repositories.Abstract
{
    public interface IEditoraServices
    {
        bool Add(Editora model);
        bool Update(Editora model);
        bool Delete(int id);
        Editora FindById(int id);
        IEnumerable<Editora> GetAll();
    }
}
