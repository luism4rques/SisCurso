using System.Linq;
using Dapper;
using DTO;

namespace DAO.SQLite
{
    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {
        public UsuarioDAO() : base()
        {

        }

        public void Criar(UsuarioDTO usuarioDTO)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Usuario
                    (  Email, Senha ) VALUES
                    (  @Email, @Senha );", usuarioDTO);
            }
        }

        public UsuarioDTO Consultar(string email)
        {
            using (var con = Connection)
            {
                con.Open();
                UsuarioDTO result = con.Query<UsuarioDTO>(
                    @"SELECT Id, Email, Senha
                    FROM Usuario
                    WHERE Email = @Email", new { email }).FirstOrDefault();
                return result;
            }
        }
    }
}