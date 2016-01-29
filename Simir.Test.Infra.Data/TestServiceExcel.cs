using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simir.Infra.Data.ServiceAgents;
using System.Linq;
using System.Diagnostics;
using Simir.Domain.Entities;

namespace Simir.Test.Infra.Data
{
    [TestClass]
    public class TestServiceExcel
    {
        private ServiceExcel _excel;
        [TestInitialize]
        public void Inicia()
        {
            _excel = new ServiceExcel();
        }
        [TestCleanup]
        public void Finaliza()
        {
            _excel.Dispose();
        }
        
        [TestMethod]
        public void GetAllUf()
        {
            var ufs = _excel.GetAllUf();

            Assert.IsTrue(ufs.Count() == 27);
            CollectionAssert.AllItemsAreUnique(ufs.Select(l => l.LocalidadeUfId).ToList());

        }
        [TestMethod]
        public void GetAllMesorregiao()
        {
            var loc = _excel.GetAllMesorregiao();

            Assert.IsTrue(loc.Count() > 27);
            foreach (LocalidadeMesorregiao item in loc)
            {
                Assert.AreNotEqual(0, item.LocalidadeMesorregiaoId);
                Assert.AreNotEqual(0, item.LocalidadeUfId);
            }
            CollectionAssert.AllItemsAreUnique(loc.Select(l => l.LocalidadeMesorregiaoId).ToList());

        }
        [TestMethod]
        public void GetAllMicrorregiao()
        {
            var loc = _excel.GetAllMicrorregiao();

            Assert.IsTrue(loc.Count() > 27);
            foreach (LocalidadeMicrorregiao item in loc)
            {
                Assert.AreNotEqual(0, item.LocalidadeMesorregiaoId);
                Assert.AreNotEqual(0, item.LocalidadeMicrorregiaoId);
            }
            CollectionAssert.AllItemsAreUnique(loc.Select(l => l.LocalidadeMicrorregiaoId).ToList());

        }
        [TestMethod]
        public void GetAllMunicipio()
        {
            var loc = _excel.GetAllMunicipio();

            Assert.IsTrue(loc.Count() > 27);
            foreach (LocalidadeMunicipio item in loc)
            {
                Assert.AreNotEqual(0, item.LocalidadeMunicipioId);
                Assert.AreNotEqual(0, item.LocalidadeMicrorregiaoId);
                Assert.AreNotEqual(0, item.LocalidadeUfId);
            }
            CollectionAssert.AllItemsAreUnique(loc.Select(l => l.LocalidadeMunicipioId).ToList());
            Debug.WriteLine(loc.Count());
        }
        [TestMethod]
        public void GetAllDistrito()
        {
            var loc = _excel.GetAllDistrito();

            Assert.IsTrue(loc.Count() > 27);

            Debug.WriteLine(loc.First().LocalidadeDistritoCodigo);
            Debug.WriteLine(loc.First().GetIdUf());
            Debug.WriteLine(loc.First().GetIdMunicipio());
            Debug.WriteLine(loc.First().GetIdDistrito());
            Debug.WriteLine(loc.First().GetIdSubDistrito());

            foreach (LocalidadeDistrito item in loc)
            {
                Assert.IsFalse(String.IsNullOrWhiteSpace(item.Nome));
                Assert.IsFalse(String.IsNullOrWhiteSpace(item.LocalidadeDistritoCodigo), item.Nome);
                Assert.AreNotEqual(0, item.LocalidadeMunicipioId, item.Nome);
                Assert.IsFalse(item.IsValido(), item.Nome);

                Assert.IsFalse(item.Nome.Length > 100);
                if(item.IsSubDistrito())
                    Assert.IsFalse(item.SubNome.Length > 100);
                Assert.IsFalse(item.LocalidadeDistritoCodigo.Length > 11);
            }
            var ids = loc.Select(l => l.LocalidadeDistritoCodigo).ToList();
            CollectionAssert.AllItemsAreUnique(ids);

        }
    }
}
