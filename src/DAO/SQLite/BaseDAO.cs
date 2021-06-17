using System;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace DAO.SQLite
{
    public class BaseDAO
    {
        protected string DataSourceFile => Environment.CurrentDirectory + "\\SisCursoDB.sqlite";
        protected SQLiteConnection Connection => new SQLiteConnection("Data Source=" + DataSourceFile + ";foreign keys=true;");

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
                            Id        integer primary key autoincrement,
                            ContatoId integer,
                            Numero    varchar(100) not null,
                            FOREIGN KEY (ContatoId) REFERENCES Contato(Id)
                        );
                      create table Usuario
                        (
                            Id    integer primary key autoincrement,
                            Email varchar(100) not null,
                            Senha varchar(100) not null
                        );
                      create table Operacao
                        (
                            Id     int primary key,
                            Titulo varchar(100) not null
                        );
                      create table Funcionalidade
                        (
                            Id     int primary key,
                            Titulo varchar(100) not null
                        );
                      create table Permissao
                        (
                            Id               integer primary key autoincrement,
                            UsuarioId        integer not null,
                            FuncionalidadeId integer not null,
                            OperacaoId       integer not null,
                            Valor            char(1) not null,
                            CONSTRAINT chk_valor CHECK (Valor in ('s','n')),
                            FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id),
                            FOREIGN KEY (FuncionalidadeId) REFERENCES Funcionalidade(Id),
                            FOREIGN KEY (OperacaoId) REFERENCES Operacao(Id),
                            CONSTRAINT uq_permissao UNIQUE (UsuarioId, FuncionalidadeId, OperacaoId)
                        );
                      insert into Operacao (Id, Titulo) values (1, 'Criar'), (2, 'Consultar'), (3, 'Atualizar'), (4, 'Excluir');
                      insert into Funcionalidade (Id, Titulo) values (1, 'Permissao'), (2, 'Contato'), (3, 'Telefone');
                      insert into Usuario (Email, Senha) values ('root@root.com', '$2a$11$Yy0eStMCUoWCxjrBJbBOHuvfWeWqtsgGUDyGIF8cf.M6yZ9/nBMSK');
                      insert into Permissao (UsuarioId, FuncionalidadeId, OperacaoId, Valor) values (1, 1, 1, 's'),(1, 1, 2, 's'),(1, 1, 3, 's'),(1, 1, 4, 's');
                    "
                    //Email = root@root.com / Senha = 123123
                );
            }
        }
    }
}