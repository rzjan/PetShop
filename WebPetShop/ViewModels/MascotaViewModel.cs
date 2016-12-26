using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebPetShop.Models
{
    public class MascotaViewModel
    {
        //PROPIEDADES
        [Key]
        public int MascotaID { get; set; }
        [Required(ErrorMessage="Este campo es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public Int16 Edad { get; set; }
        public Raza Raza { get; set; }
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Estado { get; set; }
        public string Foto { get; set; }
        public Animal Animal { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}