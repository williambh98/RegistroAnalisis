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
   public class RepositorioPago : RepositorioBase<Pago>
    {
        public override Pago Buscar(int id)
        {
            Pago pago = new Pago();

            try
            {
                pago = _contexto.pagos.Find(id);
   
            }
            catch (Exception)
            {
                throw;
            }
            return pago;
             
        }

        public override bool Guardar (Pago entity)
        {
            RepositorioAnalisis repositorio = new RepositorioAnalisis();
            Contexto contexto = new Contexto();
            foreach(var intem in entity.PagoDetalles.ToList())
            {
                var Analisis = repositorio.Buscar(intem.AnalisisID);
                Analisis.Balance -= Analisis.Monto;
                contexto.Entry(Analisis).State = System.Data.Entity.EntityState.Modified;
            }
            bool paso = contexto.SaveChanges() > 0;
            repositorio.Dispose();
            if(paso)
            {
                contexto.Dispose();
                return base.Guardar(entity);

            }
            contexto.Dispose();
            return false;

        }

        public override bool Modificar(Pago entity)
        {
            var anterior = Buscar(entity.IDpago);
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                using (Contexto contexto1 = new Contexto())
                {
                    bool paso1 = false;
                    foreach(var item in anterior.PagoDetalles.ToList())
                    {
                        if(!entity.PagoDetalles.Exists(p => p.PagoDetalleID == item.PagoDetalleID))
                        {
                            RepositorioAnalisis repsoitorio = new RepositorioAnalisis();
                            var A = repsoitorio.Buscar(item.AnalisisID);
                            A.Balance += item.Monto;
                            contexto.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                            contexto.Entry(A).State = System.Data.Entity.EntityState.Modified;
                            paso1 = true;
                            contexto1.SaveChanges();
                            repsoitorio.Dispose();
                        }
                    }
                   foreach(var item in entity.PagoDetalles)
                    {
                        var pago = EntityState.Unchanged;
                        if(item.PagoDetalleID == 0)
                        {
                            RepositorioAnalisis repositorio = new RepositorioAnalisis();
                            var A = repositorio.Buscar(item.AnalisisID);
                            A.Balance -= item.Monto;
                            pago = EntityState.Added;
                            contexto.Entry(A).State = EntityState.Modified;
                            repositorio.Dispose();
                        }
                        contexto.Entry(item).State = pago;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar (int id)
        {
            RepositorioAnalisis repositorio = new RepositorioAnalisis();
            Pago pago = Buscar(id);
            Contexto contexto = new Contexto();
            foreach(var item in pago.PagoDetalles.ToList())
            {
                var A = repositorio.Buscar(item.AnalisisID);
                A.Monto += item.Monto;
                contexto.Entry(A).State = EntityState.Modified;
                
            }
            bool paso = contexto.SaveChanges() > 0;
            if (paso)
            {
                contexto.Dispose();
                return base.Eliminar(pago.IDpago);
            }
            contexto.Dispose();
            return false;

        }


    }


}
