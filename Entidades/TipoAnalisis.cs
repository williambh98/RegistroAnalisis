using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
   public class TipoAnalisis
    {
        [Key]
        public int TipoID { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime fecha { get; set; }

        public TipoAnalisis()
        {
            TipoID = 0;
            Monto = 0;
            Descripcion = string.Empty;
            fecha = DateTime.Now;
        }

        public TipoAnalisis(int tipoID, string descripcion, decimal monto, DateTime fecha)
        {
            TipoID = tipoID;
            Descripcion = descripcion;
            Monto = monto;
            this.fecha = fecha;
        }
    }
}
