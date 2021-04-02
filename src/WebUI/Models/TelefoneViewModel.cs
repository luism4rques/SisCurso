using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class TelefoneViewModel
    {
        public int Id { get; set; }
        public int ContatoId { get; set; }

        [Required(ErrorMessage = "O 'Telefone' deve ser preenchido.")]
        [MinLength(9, ErrorMessage = "O 'Telefone' deve ter no mínimo 9 caracteres.")]
        [MaxLength(100, ErrorMessage = "O 'Telefone' deve ter no máximo 20 caracteres.")]
        [DisplayName("Telefone")]
        public string Numero { get; set; }
    }
}