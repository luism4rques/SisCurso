using System.Collections.Generic;
using System.Linq;
using Dapper;
using DTO;

namespace DAO.SQLite
{
    public class PermissaoDAO : BaseDAO
    {
        public PermissaoDAO() : base()
        {

        }

        public void Criar(PermissaoDTO permissaoDTO)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Permissao
                    (  UsuarioId, FuncionalidadeId, OperacaoId, Valor ) VALUES
                    (  @UsuarioId, @FuncionalidadeId, @OperacaoId, @Valor );", permissaoDTO);
            }
        }
        
        public List<PermissaoDTO> Consultar(int usuarioId)
        {
            using (var con = Connection)
            {
                con.Open();
                var result = con.Query<PermissaoDTO>(
                    @"SELECT Id, UsuarioId, FuncionalidadeId, OperacaoId, Valor
                    FROM Permissao
                    WHERE UsuarioId = @UsuarioId", new { usuarioId }
                ).ToList();
                return result;
            }
        }

        public void Atualizar(PermissaoDTO permissaoDTO)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"UPDATE Permissao SET 
                    Nome = @Nome, SobreNome = @SobreNome, Email = @Email
                    WHERE Id = @Id;", permissaoDTO);
            }
        }

        //  create table Permissao
        // UsuarioId integer not null,
        // FuncionalidadeId integer not null,
        // OperacaoId integer not null,
        // Valor char(1) not null,

        // public PermissaoDTO Consultar(int id)
        // {
        //     using (var con = Connection)
        //     {
        //         con.Open();
        //         PermissaoDTO result = con.Query<PermissaoDTO>(
        //             @"SELECT
        //             f.Titulo || '-' || o.Titulo AS Titulo, 
        //             COALESCE(p.Valor, 'n') AS Valor
        //             FROM Funcionalidade f 
        //             JOIN Permissao p ON f.Id = p.FuncionalidadeId
        //             JOIN Operacao o ON o.Id = p.OperacaoId
        //             JOIN Usuario u ON u.Id = p.UsuarioId
        //             WHERE u.Id = @id", new { id }).FirstOrDefault();
        //         return result;
        //     }
        // }

        // public List<FuncionalidadeDTO> Consultar()
        // {
        //     using (var con = Connection)
        //     {
        //         con.Open();
        //         var result = con.Query<FuncionalidadeDTO>(
        //             @"SELECT Id, Titulo
        //             FROM Funcionalidade"
        //         ).ToList();
        //         return result;
        //     }
        // }
    }
}