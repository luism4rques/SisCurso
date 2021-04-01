using System.ComponentModel;

namespace WebUI.Models
{
    public class Contato
    {
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Sobrenome")]
        public string SobreNome { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}