using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPetShop.Models
{
    public class MascotasVM
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
    }
}