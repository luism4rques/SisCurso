using System;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace DAO
{
    public class BaseDAO
    {
        protected string DataSourceFile => Environment.CurrentDirectory + "\\SisCursoDB.sqlite";
        protected SQLiteConnection Connection => new SQLiteConnection("Data Source=" + DataSourceFile);

        public BaseDAO()
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
                        );
                      create table Telefone
                        (
                            Id integer primary key autoincrement,
                            ContatoId integer,
                            Numero varchar(100) not null,
                            FOREIGN KEY (ContatoId) REFERENCES Contato(Id)
                        );");
            }
        }
    }
}