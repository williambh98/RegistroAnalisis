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
        public override Analisis Buscar(int id)
        {
            Analisis analisis = new Analisis();
            try
            {
                analisis = _contexto.Analisis.Find(id);
                analisis.detalle.Count();
                foreach (var item in analisis.detalle)
                {
                    string s = item.TipoAnalisis.Descripcion;
                }
                
            }
            catch(Exception)
            {
                throw;
            }
            return analisis;
        }

        public override bool Modificar(Analisis analisis)
        {
            bool paso = false;
            try
            {
                foreach (var item in analisis.detalle)
                {
                    var estado = item.AnalisisID > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(analisis).State = estado;

                }

                _contexto.Entry(analisis).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch(Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
