using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Models.Domain
{
    public class Livro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Ano { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Isbn { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int PaginasTotal { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Digite um valor válido para o preço.")]
        public double PrecoLivro { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int AutorId { get; set; }
        [Required]
        public int EditoraId { get; set; }
        [Required]
        public int GeneroId { get; set; }

        [NotMapped]
        public string? AutorNome { get; set; }
        [NotMapped]
        public string? EditoraNome { get; set; }
        [NotMapped]
        public string? GeneroTipo { get; set; }

        [NotMapped]
        public List<SelectListItem>? ListaAutores { get; set; }
        [NotMapped]
        public List<SelectListItem>? ListaEditores { get; set; }
        [NotMapped]
        public List<SelectListItem>? ListaGeneros { get; set; }
    }
}
