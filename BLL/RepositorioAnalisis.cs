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
        public RepositorioAnalisis() : base()
        {

        }
        public override bool Guardar(Analisis entity)
        {
            entity.Balance = entity.Monto;
            return base.Guardar(entity);
        }
        public override Analisis Buscar(int id)
        {
            Analisis analisis = new Analisis();
            try
            {
                analisis = _contexto.Analisis.AsNoTracking().Where(x => x.AnalisisID == id).FirstOrDefault();
                if (analisis != null)
                    analisis.detalle.Count();


            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
                _contexto = new Contexto();
            }
            return analisis;
        }
        public override bool Modificar(Analisis analisis)
        {
            var Anterior = Buscar(analisis.AnalisisID);
            bool paso = false;
            try
            {
                foreach (var item in Anterior.detalle.ToList())
                {
                    if (!analisis.detalle.Exists(d => d.DetalleID == item.DetalleID))
                    {
                        item.TipoAnalisis = null;
                        _contexto.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                foreach (var item in analisis.detalle)
                {

                    Contexto contexto = new Contexto();
                    var estado = item.DetalleID > 0 ? EntityState.Unchanged : EntityState.Added;
                    contexto.Entry(item).State = estado;
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
