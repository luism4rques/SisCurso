using System.Collections.Generic;
using DTO;

namespace DAO
{
    public interface ITelefoneDAO
    {
        void Atualizar(TelefoneDTO telefoneDTO);
        TelefoneDTO Consultar(int id);
        List<TelefoneDTO> ConsultarPorContato(int contatoId);
        void Criar(TelefoneDTO telefoneDTO);
        void Excluir(int id);
    }
}