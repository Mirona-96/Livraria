using Livraria.Models.Domain;
using Livraria.Repositories.Abstract;

namespace Livraria.Repositories.Implementation
{
    public class GeneroServices : IGeneroServices
    {

        private readonly LivrariaDbContext context;

        public GeneroServices(LivrariaDbContext context)
        {
            this.context = context;
        }

        public bool Add(Genero model)
        {
            try
            {
                context.Genero.Add(model);
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
                context.Genero.Remove(data);
                 context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genero FindById(int id)
        {
            return context.Genero.Find(id);
        }

        public IEnumerable<Genero> GetAll()
        {
            return context.Genero.ToList();
        }

        public bool Update(Genero model)
        {
            try
            {
                context.Genero.Update(model);
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
