using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioAnalisis : RepositorioBase<Analisis>
    {
        public override bool Guardar(Analisis entity)
        {
            entity.Balance = entity.Monto;
            return base.Guardar(entity);
        }
        public override Analisis Buscar(int id)
        {
            Analisis analisis = new Analisis();
            Contexto con = new Contexto();
            try
            {
                analisis = _contexto.Analisis.Find(id);
                if(analisis != null)
                    analisis.detalle.Count();
               

            }
            catch (Exception)
            {
                throw;
            }
            return analisis;
        }
        public override bool Modificar(Analisis analisis)
        {
            var Anterior = _contexto.Analisis.Find(analisis.AnalisisID);
            bool paso = false;
            try
            {
                
                foreach (var item in Anterior.detalle)
                {
                    if (!analisis.detalle.Exists(d => d.DetalleID == item.DetalleID))
                    {
                        item.TipoAnalisis = null;
                        _contexto.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                foreach (var item in analisis.detalle)
                {

                    var estado = item.DetalleID > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }
                _contexto.Entry(analisis).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch
            {
                throw;
            }
            return paso;
        }

    }
}
