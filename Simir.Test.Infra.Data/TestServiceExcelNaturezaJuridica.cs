using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simir.Infra.Data.ServiceAgents;
using System.Diagnostics;
using System.Collections.Generic;
using Simir.Domain.Entities;

namespace Simir.Test.Infra.Data
{
    [TestClass]
    public class TestServiceExcelNaturezaJuridica
    {
        private ServiceExcelNaturezaJuridica _excel;
        [TestInitialize]
        public void Inicia()
        {
            _excel = new ServiceExcelNaturezaJuridica();
        }
        [TestCleanup]
        public void Finaliza()
        {
            _excel.Dispose();
        }

        [TestMethod]
        public void GetAllNaturezaJuridica()
        {
            /*
            IEnumerable<NaturezaJuridica> log = _excel.GetAllNaturezaJuridica();

            
            Assert.IsTrue(log. > 20);
            CollectionAssert.AllItemsAreUnique(log.Select(l => l.LocalidadeLogradouroTipoId).ToList());
            
            foreach (var item in log)
            {
                Debug.WriteLine(item.Qualificacao);
            }
             */

        }
    }
}
