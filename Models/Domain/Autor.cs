using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Domain
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string AutorNome { get; set; }
    }
}
