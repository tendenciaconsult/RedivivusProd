using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simir.Infra.Data.ServiceAgents;
using System.Diagnostics;
using System.Collections.Generic;
using Simir.Domain.Entities;

namespace Simir.Test.Infra.Data
{
    [TestClass]
    public class TestServiceExcelRS
    {
        private ServiceExcelRS _excel;
        [TestInitialize]
        public void Inicia()
        {
            _excel = new ServiceExcelRS();
        }
        [TestCleanup]
        public void Finaliza()
        {
            _excel.Dispose();
        }

        [TestMethod]
        public void GetAllCapitulo()
        {
            IEnumerable<TipoResiduoCapitulo> log = _excel.GetAllCapitulo();

            int tam = 0;
            foreach (TipoResiduoCapitulo item in log)
            {
                if (item.Descricao.Length > tam) tam = item.Descricao.Length;

                Debug.WriteLine(item.TipoResiduoId+" "+ item.Codigo + " " + item.Descricao);
            }
            
        }

        [TestMethod]
        public void GetAllSubCapitulo()
        {
            IEnumerable<TipoResiduoSubcapitulo> log = _excel.GetAllSubcapitulo();

            int tam = 0;
            foreach (TipoResiduoSubcapitulo item in log)
            {
                if (item.Descricao.Length > tam) tam =item.Descricao.Length;

                Debug.WriteLine(item.TipoResiduoId + " " + item.Codigo + " " + item.TipoResiduoCapituloId + " " + item.Descricao);
            }

        }
        [TestMethod]
        public void GetAllDetalhe()
        {
            IEnumerable<TipoResiduoDetalhe> log = _excel.GetAllDetalhe();

            int tam = 0;
            foreach (TipoResiduoDetalhe item in log)
            {
                if (item.Descricao.Length > tam) tam = item.Descricao.Length;

                Debug.WriteLine(item.TipoResiduoId + " " + item.Codigo + " " +  item.TipoResiduoSubcapituloId + " " + item.Descricao + " " + item.IsPerigoso);
            }

        }

        [TestMethod]
        public void TrabalhandoStrings()
        {
            var test = "     ";

            Debug.WriteLine(test.Split(' ')[0]);
        }
    }
}
