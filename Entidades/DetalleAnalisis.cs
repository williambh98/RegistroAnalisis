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

        public string resultado { get; set; }

        [ForeignKey("TipoID")]
        public virtual TipoAnalisis TipoAnalisis { get; set; }
        public DetalleAnalisis()
        {

        }

        public DetalleAnalisis(int detalleID, int analisisID)
        {
            DetalleID = detalleID;
            AnalisisID = analisisID;
        }
    }
}
