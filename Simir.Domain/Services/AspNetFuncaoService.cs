using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using Simir.Domain.Entities;
using Simir.Domain.Enuns;
using Simir.Domain.Interfaces.Repository;
using Simir.Domain.Interfaces.Services;

namespace Simir.Domain.Services
{
    public class AspNetFuncaoService : ServiceBase<AspNetFuncao>, IAspNetFuncaoService
    {
        private new readonly IAspNetFuncaoRepository _repository;

        public AspNetFuncaoService(IAspNetFuncaoRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public new IEnumerable<AspNetFuncao> GetAll()
        {
            return _repository.Get();
        }

        public bool UpdateFuncao(TipoEmpresa tipoEmpresa, string nome, string descricao, int maxFuncionarios)
        {
            var funcao = _repository.Find(x => x.Nome == nome).FirstOrDefault();
            if (funcao == null)
            {
                _repository.Add(new AspNetFuncao
                {
                    Nome = nome,
                    Descricao = descricao,
                    TipoEmpresa = tipoEmpresa,
                    MaxFuncionarios = maxFuncionarios
                });
            }
            else
            {
                if (funcao.Descricao == descricao && funcao.MaxFuncionarios == maxFuncionarios) return false;

                funcao.Descricao = descricao;
                funcao.MaxFuncionarios = maxFuncionarios;
                _repository.Update(funcao);
            }
            return true;
        }

        public bool AddUsuarioToFuncao(AspNetUser usuario, string funcaoNome)
        {
            var funcao = _repository.Find(x => x.Nome == funcaoNome).FirstOrDefault();
            if (funcao == null) throw new ArgumentException("funcaoNome");

            //*
            if (funcao.Usuarios.Contains(usuario)) return false;

            funcao.Usuarios.Add(usuario);
            //*/

            /*
            if (usuario.Funcoes.Contains(funcao)) return false;

            usuario.Funcoes.Add(funcao);
             */
            return true;
        }

        public bool AddFuncaoToPerfil(string funcaoNome, int perfilId,
            IAspNetPerfilRepository simirPerfilRepository = null)
        {
            var funcao = _repository.Find(x => x.Nome == funcaoNome).FirstOrDefault();
            if (funcao == null) throw new ArgumentException("funcaoNome");

            if (funcao.PerfilId == perfilId) return false;

            simirPerfilRepository = simirPerfilRepository ??
                                    ServiceLocator.Current.GetInstance<IAspNetPerfilRepository>();

            var perfil = simirPerfilRepository.GetById(perfilId);
            if (perfil == null) throw new ArgumentException("perfilNome");

            funcao.PerfilId = perfilId;
            //*/
            return true;
        }

        public bool AddFuncaoToPerfil(string funcaoNome, string perfilNome,
            IAspNetPerfilRepository simirPerfilRepository = null)
        {
            var funcao = _repository.Find(x => x.Nome == funcaoNome).FirstOrDefault();
            if (funcao == null) throw new ArgumentException("funcaoNome");


            //*
            if (funcao.Perfil != null && funcao.Perfil.Nome == perfilNome) return false;


            if (simirPerfilRepository == null)
            {
                simirPerfilRepository = ServiceLocator.Current.GetInstance<IAspNetPerfilRepository>();
            }

            var perfil = simirPerfilRepository.Find(x => x.Nome == perfilNome).FirstOrDefault();
            if (perfil == null) throw new ArgumentException("perfilNome");

            funcao.PerfilId = perfil.AspNetPerfilId;
            //*/
            return true;
        }

        public AspNetFuncao GetFuncaoByNome(string funcaoNome)
        {
            return _repository.Find(x => x.Nome == funcaoNome).FirstOrDefault();
        }
    }
}