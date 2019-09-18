using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Pago
    {
        [Key]
        public int IDpago { get; set; }
        public DateTime Fecha { get; set; }

        public virtual List<PagoDetalle> PagoDetalles { get; set; }
        
        public Pago()
        {
            this.IDpago = 0;
            this.Fecha = DateTime.Now;
            this.PagoDetalles = new List<PagoDetalle>(0);

        }

        public void AgregarDetalle(int PagoDetalleID, int IDpago, int AnalisisID, decimal Monto, DateTime Fecha)
        {
            PagoDetalles.Add(new PagoDetalle(PagoDetalleID, IDpago, AnalisisID, Monto, Fecha));
        }
        public Pago(int dpago, DateTime fecha, List<PagoDetalle> pagoDetalles)
        {
            IDpago = dpago;
            Fecha = fecha;
            PagoDetalles = pagoDetalles;
        }

        public void RemoverPAgoDetalle(int Index)
        {
            this.PagoDetalles.RemoveAt(Index);
        }

    }
   
}
