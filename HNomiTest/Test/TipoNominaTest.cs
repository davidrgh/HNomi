using HNomi.Controllers;
using HNomi.Entities;
using HNomi.Models;
using HNomi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HNomiTest.Test
{
    [TestClass]
    public class TipoNominaTest
    {
        private TipoNominaServiceFake _fake;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            AutoMapper.Mapper.Initialize(cfg =>

            {
                cfg.CreateMap<TipoNominaEntity, TipoNomina>();
                cfg.CreateMap<TipoNomina, TipoNominaEntity>();
                cfg.CreateMap<TipoNominaModel, TipoNomina>();
                cfg.CreateMap<TipoNominaEntity, EstructuraNomina>();

                cfg.CreateMap<DetallesTipoNominaEntity, DetallesTipoNomina>();
                cfg.CreateMap<DetallesTipoNomina, DetallesTipoNominaEntity>();
                cfg.CreateMap<DetallesTipoNominaModel, DetallesTipoNomina>();

                cfg.CreateMap<ImpuestosEntity, Impuesto>();
                cfg.CreateMap<Impuesto, ImpuestosEntity>();
                cfg.CreateMap<ImpuestosModel, Impuesto>();

                cfg.CreateMap<TurnosTrabajoEntity, TurnosTrabajo>();
                cfg.CreateMap<TurnosTrabajo, TurnosTrabajoEntity>();
                cfg.CreateMap<TurnosTrabajoModel, TurnosTrabajo>();

                cfg.CreateMap<BusquedaFechasModel, BusquedaFechas>();
            }

            );
        }

        [TestInitialize]
        public void Init()
        {
            _fake = new TipoNominaServiceFake();
            
        }

        [TestMethod]
        public void ObtenerDevuelveOKResultConElObjetoSolicitadoPorId()
        {
            // Arrange
            var tipoNominaContoller = new TipoNominaController(_fake);

            // Act
            var response = tipoNominaContoller.Obtener(1).Result;

            // Assert            
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));  // Es de tipo OkResult y devuelve un objeto (OkObjectResult)
            Assert.IsInstanceOfType((response as OkObjectResult).Value, typeof(TipoNomina)); // El objeto devuelto es de tipo TipoNomina
            Assert.AreEqual("Nomina 1", ((response as OkObjectResult).Value as TipoNomina).Nombre); // El nombre del objeto devuelto es "Nomina 1"
        }

        [TestMethod]
        public void ObtenerDevuelveNotFoundResultSiIdEsInvalido()
        {
            // Arrange
            var tipoNominaContoller = new TipoNominaController(_fake);

            // Act
            var response = tipoNominaContoller.Obtener(10).Result;

            // Assert            
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));  // Es de tipo NotFound y devuelve un objeto (NotFoundResult)
            
        }

        [TestMethod]
        public void NuevoDevuelveOKResultConElObjetoCreado()
        {
            // Arrange
            var tipoNominaContoller = new TipoNominaController(_fake);

            // Act
            TipoNominaModel tipoNomna = new TipoNominaModel()
            {
                Nombre = "Nomina 4",
                Nocturnidad = new DateTime(2019, 1, 1, 20, 0, 0)
            };
            var response = tipoNominaContoller.Nuevo(tipoNomna).Result;

            // Assert            
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));  // Es de tipo OkResult y devuelve un objeto (OkObjectResult)
            Assert.IsInstanceOfType((response as OkObjectResult).Value, typeof(TipoNomina)); // El objeto devuelto es de tipo TipoNomina
            Assert.AreEqual("Nomina 4", ((response as OkObjectResult).Value as TipoNomina).Nombre); // El nombre del objeto devuelto es "Nomina 4"
        }

        [TestMethod]
        public void NuevoDevuelveBadRequestSiFaltaElNombre()
        {
            // Arrange
            var tipoNominaContoller = new TipoNominaController(_fake);

            // Act
            TipoNominaModel tipoNomna = new TipoNominaModel()
            {
                Nombre = null,
                Nocturnidad = new DateTime(2019, 1, 1, 20, 0, 0)
            };
            var response = tipoNominaContoller.Nuevo(tipoNomna).Result;

            // Assert            
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));  // Es de tipo OkResult y devuelve un objeto (OkObjectResult)
        }
    }
}
