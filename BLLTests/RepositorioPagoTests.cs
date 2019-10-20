using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BLL.Tests
{
    [TestClass()]
    public class RepositorioPagoTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Pago pago = new Pago();
            pago.Fecha = DateTime.Now;

            RepositorioBase<Pago> repositorioBase = new RepositorioBase<Pago>();
            Assert.IsTrue(repositorioBase.Guardar(pago));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Pago pago = new Pago();
            pago.IDpago = 1;
            pago.Fecha = DateTime.Now;

            RepositorioBase<Pago> repositorioBase = new RepositorioBase<Pago>();
            Assert.IsTrue(repositorioBase.Modificar(pago));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            int id = 2;
            Pago pago = new Pago();
            RepositorioBase<Pago> repositorioBase = new RepositorioBase<Pago>();
            pago = repositorioBase.Buscar(id);
            Assert.AreEqual(true, pago != null);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Pago pago = new Pago();
            RepositorioBase<Pago> repositorioBase = new RepositorioBase<Pago>();
            pago.IDpago = 1;
            Assert.AreEqual(true, repositorioBase.Eliminar(pago.IDpago));
        }
    }
}