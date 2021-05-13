using System.Collections.Generic;
using AutoMapper;
using DAO;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class PermissaoController : Controller
    {
        private readonly IUsuarioDAO _usuarioDAO;
        private readonly IMapper _mapper;

        public PermissaoController(IUsuarioDAO usuarioDAO, IMapper mapper)
        {
            _usuarioDAO = usuarioDAO;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var lstUsuarioDTO = _usuarioDAO.Consultar();
            var lstUsuarioViewModel = new List<UsuarioViewModel>();

            foreach(var dto in lstUsuarioDTO)
            {
                lstUsuarioViewModel.Add(_mapper.Map<UsuarioViewModel>(dto));
            }

            return View(lstUsuarioViewModel);
        }

        public ActionResult Update(int usuarioId)
        {
            var vm = new PermissaoViewModel();
            var permissaoDAO = new DAO.SQLite.PermissaoDAO();
            var usuarioDAO = new DAO.SQLite.UsuarioDAO();

            var lst = permissaoDAO.Consultar(usuarioId);
            vm.UsuarioId = usuarioId;

            var dto = lst.Find(o => o.FuncionalidadeId == DAO.Constants.Funcionalidade.CONTATO &&
                o.OperacaoId == DAO.Constants.Operacao.CRIAR);

            vm.Contato_Criar_Id = dto?.Id??0;
            vm.Contato_Criar = dto?.Valor??DAO.Constants.Permissao.VALOR_N;

            dto = lst.Find(o => o.FuncionalidadeId == DAO.Constants.Funcionalidade.CONTATO &&
                o.OperacaoId == DAO.Constants.Operacao.CONSULTAR);

            vm.Contato_Consultar_Id = dto?.Id??0;
            vm.Contato_Consultar = dto?.Valor??DAO.Constants.Permissao.VALOR_N;

            dto = lst.Find(o => o.FuncionalidadeId == DAO.Constants.Funcionalidade.CONTATO &&
                o.OperacaoId == DAO.Constants.Operacao.ATUALIZAR);

            vm.Contato_Atualizar_Id = dto?.Id??0;
            vm.Contato_Atualizar = dto?.Valor??DAO.Constants.Permissao.VALOR_N;

            dto = lst.Find(o => o.FuncionalidadeId == DAO.Constants.Funcionalidade.CONTATO &&
                o.OperacaoId == DAO.Constants.Operacao.EXCLUIR);

            vm.Contato_Excluir_Id = dto?.Id??0;
            vm.Contato_Excluir = dto?.Valor??DAO.Constants.Permissao.VALOR_N;

            dto = lst.Find(o => o.FuncionalidadeId == DAO.Constants.Funcionalidade.TELEFONE &&
                o.OperacaoId == DAO.Constants.Operacao.CRIAR);

            vm.Telefone_Criar_Id = dto?.Id??0;
            vm.Telefone_Criar = dto?.Valor??DAO.Constants.Permissao.VALOR_N;

            dto = lst.Find(o => o.FuncionalidadeId == DAO.Constants.Funcionalidade.TELEFONE &&
                o.OperacaoId == DAO.Constants.Operacao.CONSULTAR);

            vm.Telefone_Consultar_Id = dto?.Id??0;
            vm.Telefone_Consultar = dto?.Valor??DAO.Constants.Permissao.VALOR_N;

            dto = lst.Find(o => o.FuncionalidadeId == DAO.Constants.Funcionalidade.TELEFONE &&
                o.OperacaoId == DAO.Constants.Operacao.ATUALIZAR);

            vm.Telefone_Atualizar_Id = dto?.Id??0;
            vm.Telefone_Atualizar = dto?.Valor??DAO.Constants.Permissao.VALOR_N;

            dto = lst.Find(o => o.FuncionalidadeId == DAO.Constants.Funcionalidade.TELEFONE &&
                o.OperacaoId == DAO.Constants.Operacao.EXCLUIR);

            vm.Telefone_Excluir_Id = dto?.Id??0;
            vm.Telefone_Excluir = dto?.Valor??DAO.Constants.Permissao.VALOR_N;

            return View(vm);
        }

        private void CriarOuAtualizarPermissao(int id, int usuarioId, int funcionalidadeId, int operacaoId, string valor)
        {
            var dao = new DAO.SQLite.PermissaoDAO();

            var dto = new DTO.PermissaoDTO { 
                Id = id,
                UsuarioId = 1,
                FuncionalidadeId = funcionalidadeId,
                OperacaoId = operacaoId,
                Valor = valor
            };
            
            if(dto.Id == 0)
            {
                dao.Criar(dto);
            }
            else
            {
                dao.Atualizar(dto);            
            }
        }

        [HttpPost]
        public ActionResult Update(PermissaoViewModel permissaoViewModel)
        {
            CriarOuAtualizarPermissao(permissaoViewModel.Contato_Criar_Id, permissaoViewModel.UsuarioId, 
                DAO.Constants.Funcionalidade.CONTATO, DAO.Constants.Operacao.CRIAR, permissaoViewModel.Contato_Criar);

            CriarOuAtualizarPermissao(permissaoViewModel.Contato_Excluir_Id, permissaoViewModel.UsuarioId, 
                DAO.Constants.Funcionalidade.CONTATO, DAO.Constants.Operacao.EXCLUIR, permissaoViewModel.Contato_Excluir);

            CriarOuAtualizarPermissao(permissaoViewModel.Contato_Atualizar_Id, permissaoViewModel.UsuarioId, 
                DAO.Constants.Funcionalidade.CONTATO, DAO.Constants.Operacao.ATUALIZAR, permissaoViewModel.Contato_Atualizar);

            CriarOuAtualizarPermissao(permissaoViewModel.Contato_Consultar_Id, permissaoViewModel.UsuarioId, 
                DAO.Constants.Funcionalidade.CONTATO, DAO.Constants.Operacao.CONSULTAR, permissaoViewModel.Contato_Consultar);

            CriarOuAtualizarPermissao(permissaoViewModel.Telefone_Criar_Id, permissaoViewModel.UsuarioId, 
                DAO.Constants.Funcionalidade.TELEFONE, DAO.Constants.Operacao.CRIAR, permissaoViewModel.Telefone_Criar);

            CriarOuAtualizarPermissao(permissaoViewModel.Telefone_Excluir_Id, permissaoViewModel.UsuarioId, 
                DAO.Constants.Funcionalidade.TELEFONE, DAO.Constants.Operacao.EXCLUIR, permissaoViewModel.Telefone_Excluir);

            CriarOuAtualizarPermissao(permissaoViewModel.Telefone_Atualizar_Id, permissaoViewModel.UsuarioId, 
                DAO.Constants.Funcionalidade.TELEFONE, DAO.Constants.Operacao.ATUALIZAR, permissaoViewModel.Telefone_Atualizar);

            CriarOuAtualizarPermissao(permissaoViewModel.Telefone_Consultar_Id, permissaoViewModel.UsuarioId, 
                DAO.Constants.Funcionalidade.TELEFONE, DAO.Constants.Operacao.CONSULTAR, permissaoViewModel.Telefone_Consultar);

            return View();
        }
    }
}