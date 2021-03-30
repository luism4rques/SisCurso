using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Dapper;
using DTO;

namespace DAL
{
    public class ContatoDAO
    {
        private string DataSourceFile => Environment.CurrentDirectory + "\\SisCursoDB.sqlite";
        public SQLiteConnection Connection => new SQLiteConnection("Data Source=" + DataSourceFile);

        public ContatoDAO()
        {
            if (!File.Exists(DataSourceFile))
            {
                CreateDatabase();
            }
        }

        private void CreateDatabase()
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"create table Contato
                        (
                            Id        integer primary key autoincrement,
                            Nome      varchar(100) not null,
                            SobreNome varchar(100) not null,
                            Email     varchar(100) not null
                        )");
            }
        }

        public void Criar(Contato contato)
        {        
            using (var con = Connection)
            {
                con.Open();
                contato.Id = con.Query<int>(
                    @"INSERT INTO Contato
                    (  Nome, SobreNome, Email ) VALUES
                    (  @Nome, @SobreNome, @Email );
                    select last_insert_rowid()", contato).First();
            }
        }

        public Contato Consultar(int id)
        {
            using (var con = Connection)
            {
                con.Open();
                Contato result = con.Query<Contato>(
                    @"SELECT Id, Nome, SobreNome, Email
                    FROM Contato
                    WHERE Id = @id", new { id }).FirstOrDefault();
                return result;
            }
        }
    }
}