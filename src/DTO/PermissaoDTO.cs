namespace DTO
{
    public class PermissaoDTO
    {
        public string Titulo { get; set; }
        public string Valor { get; set; }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int FuncionalidadeId { get; set; }
        public int OperacaoId { get; set; }
    }
}