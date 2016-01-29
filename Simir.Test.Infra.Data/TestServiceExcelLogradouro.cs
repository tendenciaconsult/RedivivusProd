using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simir.Infra.Data.ServiceAgents;
using System.Linq;
using System.Diagnostics;
using Simir.Domain.Entities;

namespace Simir.Test.Infra.Data
{
    [TestClass]
    public class TestServiceExcelLogradouro
    {
        private ServiceExcelLogradouro _excel;
        [TestInitialize]
        public void Inicia()
        {
            _excel = new ServiceExcelLogradouro();
        }
        [TestCleanup]
        public void Finaliza()
        {
            _excel.Dispose();
        }
        
        [TestMethod]
        public void GetAllLogradouroTipo()
        {
            var log = _excel.GetAllLogradouroTipo();

            Assert.IsTrue(log.Count() > 20);
            CollectionAssert.AllItemsAreUnique(log.Select(l => l.LocalidadeLogradouroTipoId).ToList());

            foreach (LocalidadeLogradouroTipo item in log)
            {
                Debug.WriteLine(item.ToString());
            }

        }
    }
}
