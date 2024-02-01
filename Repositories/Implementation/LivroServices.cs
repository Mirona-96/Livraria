using Humanizer.Localisation;
using Livraria.Models.Domain;
using Livraria.Repositories.Abstract;
using System.Security.Policy;

namespace Livraria.Repositories.Implementation
{
    public class LivroServices : IBookServices
    {

        private readonly LivrariaDbContext context;

        public LivroServices(LivrariaDbContext context)
        {
            this.context = context;
        }

       public bool Add(Livro model)
        {
            try
            {
                context.Livro.Add(model);
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
                context.Livro.Remove(data);
                context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public Livro FindById(int id)
        {
            return context.Livro.Find(id);
        }

        public IEnumerable<Livro> GetAll()
        {
            var data = (from livro in context.Livro
                        join autor in context.Autor
                        on livro.AutorId equals autor.Id
                        join editora in context.Editora on livro.EditoraId equals editora.Id
                        join genero in context.Genero on livro.GeneroId equals genero.Id
                        select new Livro
                       {
                           Id = livro.Id,
                           AutorId = livro.AutorId,
                           GeneroId = livro.GeneroId,
                           Isbn = livro.Isbn,
                           Ano = livro.Ano,
                           PrecoLivro = livro.PrecoLivro,
                           EditoraId = livro.EditoraId,
                           Titulo = livro.Titulo,
                           PaginasTotal = livro.PaginasTotal,
                           GeneroTipo = genero.Nome,
                           AutorNome = autor.AutorNome,
                           EditoraNome = editora.EditoraNome
                       }
                        ).ToList();
            return data;
        }

        public bool Update(Livro model)
        {
            try
            {
                context.Livro.Update(model);
                context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
