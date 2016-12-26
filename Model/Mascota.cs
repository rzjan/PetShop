using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Mascota
    {
        //PROPIEDADES     
        public int MascotaID { get; set; }
        public string Nombre { get; set; }
        public Int16 Edad { get; set; }
        public Raza Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Estado { get; set; }
        public string Foto { get; set; }
        public Animal Animal { get; set; }
        public DateTime FechaAlta { get; set; }

        //METODOS
    }
}
