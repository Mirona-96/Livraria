using System.ComponentModel.DataAnnotations;

namespace Livraria.Models.Domain
{
    public class Editora
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string EditoraNome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cidade { get; set;}
    }
}
