using Livraria.Models.Domain;
using Livraria.Repositories.Abstract;

namespace Livraria.Repositories.Implementation
{
    public class AutorServices : IAutorServices
    {


        private readonly LivrariaDbContext context;

        public AutorServices (LivrariaDbContext context)
        {
            this.context = context;
        }

        public bool Add(Autor model)
        {
            try
            {
                context.Autor.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
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
                context.Autor.Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Autor FindById(int id)
        {
            return context.Autor.Find(id);
        }


        public IEnumerable<Autor> GetAll()
        {
            return  context.Autor.ToList();
        }

        bool IAutorServices.Update(Autor model)
        {
            try
            {
                context.Autor.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
