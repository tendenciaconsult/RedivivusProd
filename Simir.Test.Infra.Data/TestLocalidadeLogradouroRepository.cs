using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simir.Infra.Data.Repositories;
using System.Diagnostics;
using Simir.Domain.Entities;

namespace Simir.Test.Infra.Data
{
    [TestClass]
    public class TestLocalidadeLogradouroRepository
    {
        //private LocalidadeLogradouroRepository _resp;
        [TestInitialize]
        public void Inicia()
        {
            //_resp = new LocalidadeLogradouroRepository();
        }
        [TestCleanup]
        public void Finaliza()
        {
            //_resp.Dispose();
        }

        [TestMethod]
        public void GetSimples()
        {
            //var loc = _resp.GetAll();
            //Debug.WriteLine(loc.Count());
        }

        [TestMethod]
        public void BuscarPorCep()
        {
            /*
            LocalidadeLogradouro loc;
            loc = _resp.BuscarPorCep("29010670");
            Debug.WriteLine(loc.ToString());
            loc = _resp.BuscarPorCep("29010570");
            Debug.WriteLine(loc.ToString());
            loc = _resp.BuscarPorCep("29163659");
            Debug.WriteLine(loc.ToString());
             * */
        }
    }
}
