namespace WebUI.Models
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DisplayName("Sobrenome")]
        public string SobreNome { get; set; }
        public string Email { get; set; }
    }
}