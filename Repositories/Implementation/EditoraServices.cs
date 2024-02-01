using Livraria.Models.Domain;
using Livraria.Repositories.Abstract;

namespace Livraria.Repositories.Implementation
{
    public class EditoraServices : IEditoraServices
    {

        private readonly LivrariaDbContext context;

        public EditoraServices(LivrariaDbContext context)
        {
            this.context = context;

        }

        public bool Add(Editora model)
        {
            try
            {
                context.Editora.Add(model);
                context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;
                context.Editora.Remove(data);
                context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public Editora FindById(int id)
        {
            return context.Editora.Find(id);
        }

        public IEnumerable<Editora> GetAll()
        {
            return context.Editora.ToList();
        }

        public bool Update(Editora model)
        {
            try
            {
                context.Editora.Update(model);
                context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}
