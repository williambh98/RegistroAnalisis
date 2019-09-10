using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class TipoAnalisis
    {
        [Key]
        public int TipoID { get; set; }
        public string Descripcion { get; set; }

        public TipoAnalisis()
        {
            TipoID = 0;
            Descripcion = string.Empty;
        }
       
        
        public TipoAnalisis(int tipoID, string descripcion)
        {
            TipoID = tipoID;
            Descripcion = descripcion;
        }
    }
}
