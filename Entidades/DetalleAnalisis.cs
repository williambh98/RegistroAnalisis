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
    public class DetalleAnalisis
    {
        [Key]
        public int DetalleID { get; set; }
        
        public int AnalisisID { get; set; }

        public int TipoID { get; set; }

        public string resultado { get; set; }

        [ForeignKey("TipoID")]
        public virtual TipoAnalisis TipoAnalisis { get; set; }

        [ForeignKey("AnalisisID")]
        public virtual Analisis Analisis { get; set; }

        


        public DetalleAnalisis()
        {
            DetalleID = 0;
            AnalisisID = 0;
            resultado = string.Empty;
            TipoID = 0;
        }

        public DetalleAnalisis(int detalleID, int analisisID, int tipoID, string resultado)
        {
            DetalleID = detalleID;
            AnalisisID = analisisID;
            TipoID = tipoID;
            this.resultado = resultado;
        }
    }
}
