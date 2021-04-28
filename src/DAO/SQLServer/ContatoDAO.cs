using System.Collections.Generic;
using System.Linq;
using Dapper;
using DTO;

namespace DAO.SQLServer
{
    public class ContatoDAO : BaseDAO, IContatoDAO
    {
        public ContatoDAO(string connectionString) : base(connectionString)
        {

        }

        public void Criar(ContatoDTO contatoDTO)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Contato
                    (  Nome, SobreNome, Email ) VALUES
                    (  @Nome, @SobreNome, @Email );", contatoDTO);
            }
        }

        public void Atualizar(ContatoDTO contatoDTO)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"UPDATE Contato SET 
                    Nome = @Nome, SobreNome = @SobreNome, Email = @Email
                    WHERE Id = @Id;", contatoDTO);
            }
        }

        public void Excluir(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"DELETE FROM Contato  
                    WHERE Id = @Id;", new { id });
            }
        }

        public List<ContatoDTO> Consultar()
        {
            using (var con = Connection)
            {
                con.Open();
                var result = con.Query<ContatoDTO>(
                    @"SELECT Id, Nome, SobreNome, Email
                    FROM Contato"
                ).ToList();
                return result;
            }
        }

        public ContatoDTO Consultar(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                ContatoDTO result = con.Query<ContatoDTO>(
                    @"SELECT Id, Nome, SobreNome, Email
                    FROM Contato
                    WHERE Id = @id", new { id }).FirstOrDefault();
                return result;
            }
        }
    }
}