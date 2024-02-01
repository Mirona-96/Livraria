using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Domain
{
    public class Genero
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }
    }
}
