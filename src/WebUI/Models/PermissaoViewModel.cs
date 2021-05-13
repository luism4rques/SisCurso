using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class OptionItem
    {
        public int Id {get;set;}
        public string Titulo{get;set;}
    }
    public class PermissaoViewModel
    {
        public int PermissaoId { get; set; }
        public int UsuarioId { get; set; }
        public List<OptionItem> Permissao { get; set; } = new List<OptionItem>();
        public List<OptionItem> Usuario { get; set; } = new List<OptionItem>();
        public int Contato_Consultar_Id { get; set; }
        public string Contato_Consultar { get; set; }
        public int Contato_Criar_Id { get; set; }
        public string Contato_Criar { get; set; }
        public int Contato_Atualizar_Id { get; set; }
        public string Contato_Atualizar { get; set; }
        public int Contato_Excluir_Id { get; set; }
        public string Contato_Excluir { get; set; }
        public int Telefone_Consultar_Id { get; set; }
        public string Telefone_Consultar { get; set; }
        public int Telefone_Criar_Id { get; set; }
        public string Telefone_Criar { get; set; }
        public int Telefone_Atualizar_Id { get; set; }
        public string Telefone_Atualizar { get; set; }
        public int Telefone_Excluir_Id { get; set; }
        public string Telefone_Excluir { get; set; }
    }
}