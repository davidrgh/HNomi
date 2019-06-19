using HNomi.Entities;
using HNomi.Models;
using HNomi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HNomi.Cross
{
    public static class MapperConfig
    {

        public static void Config()
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

    }
}
