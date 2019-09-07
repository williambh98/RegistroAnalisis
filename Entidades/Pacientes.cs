using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Pacientes
    {
         [Key]

        public int PacienteID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string telefono { get; set; }

        public Pacientes()
        {
            PacienteID = 0;
            Nombre = string.Empty;
            Direccion = string.Empty;
            telefono = string.Empty;
        }

        public Pacientes(int pacienteID, string nombre, string direccion, string telefono)
        {
            PacienteID = pacienteID;
            Nombre = nombre;
            Direccion = direccion;
            this.telefono = telefono;
        }
    }


}
