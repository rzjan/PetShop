using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Model
{
    public class Mascota
    {
        //PROPIEDADES     
        public int MascotaID { get; set; }
        public string Nombre { get; set; }
        public Int16 Edad { get; set; }
       
        public DateTime FechaNacimiento { get; set; }
        public string Estado { get; set; }
        public string Foto { get; set; }

        public int AnimalID { get; set; }       
        public SelectList SelectAnimal { get; set; }

        public int RazaID { get; set; }
        public SelectList SelectRaza { get; set; }
        
        public DateTime FechaAlta { get; set; }

        public Usuario Usuario { get; set; }

        //METODOS
    }
}
