using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class PagoDetalle
    {
        [Key]
        public int PagoDetalleID { get; set; }
        public int IDpago { get; set; }
        public  int AnalisisID { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("AnalisisID")]
        public virtual Analisis Analisis { get; set; }

        [ForeignKey("IDpago")]
        public virtual Pago Pago { get; set; }

        public PagoDetalle()
        {
            this.PagoDetalleID = 0;
            this.IDpago = 0;
            this.AnalisisID = 0;
            this.Monto = 0;
            this.Fecha = DateTime.Now;
        }

        public PagoDetalle(int pagoDetalleID, int dpago, int analisisID, decimal monto, DateTime fecha)
        {
            PagoDetalleID = pagoDetalleID;
            IDpago = dpago;
            AnalisisID = analisisID;
            Monto = monto;
            Fecha = fecha;
        }
    }
}
