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
    public class Analisis
    {
        [Key]
        public int AnalisisID { get; set; }
        public int PacienteID { get; set; }
        public decimal Balance { get; set; }
        public decimal Monto { get; set; }
        public DateTime fecha { get; set; }
        [ForeignKey("PacienteID")]
        public virtual Pacientes Pacientes { get; set; }
        public virtual List<DetalleAnalisis> detalle { get; set; }
       
        public Analisis()
        {
            AnalisisID = 0;
            PacienteID = 0;
            fecha = DateTime.Now;
            this.detalle = new List<DetalleAnalisis>();
        }

        public void AgragarDetalle(int DetalleID, int analisisID, int TipoID, string resultado)
        {
            this.detalle.Add(new DetalleAnalisis(DetalleID, analisisID, TipoID, resultado));
        }

        public Analisis(int analisisID, int pacienteID, DateTime fecha, List<DetalleAnalisis> detalle)
        {
            AnalisisID = analisisID;
            PacienteID = pacienteID;
            this.fecha = fecha;
            this.detalle = detalle;
        }
    

        public void RemoverDetalle(int Index)
        {
            this.detalle.RemoveAt(Index);
        }
    }    


}
