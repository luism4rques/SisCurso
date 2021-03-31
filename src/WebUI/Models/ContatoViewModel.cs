using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class ContatoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O 'Nome' deve ser preenchido.")]
        [MinLength(3, ErrorMessage = "O 'Nome' deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O 'Nome' deve ter no máximo 100 caracteres.")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O 'Sobre nome' deve ser preenchido.")]
        [MinLength(2, ErrorMessage = "O 'Sobre nome' deve ter no mínimo 2 caracteres.")]
        [MaxLength(100, ErrorMessage = "O 'Sobre nome' deve ter no máximo 100 caracteres.")]
        [DisplayName("Sobre nome")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "O 'E-mail' deve ser preenchido.")]
        [MinLength(10, ErrorMessage = "O 'E-mail' deve ter no mínimo 10 caracteres.")]
        [MaxLength(100, ErrorMessage = "O 'E-mail' deve ter no máximo 100 caracteres.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}