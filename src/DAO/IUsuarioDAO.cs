using DTO;

namespace DAO
{
    public interface IUsuarioDAO
    {
        void Criar(UsuarioDTO usuarioDTO);
        UsuarioDTO Consultar(string email);        
    }
}