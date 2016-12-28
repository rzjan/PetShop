using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
       
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        public Estado Estado { get; set; }
        public string Foto { get; set; }

        public int AnimalID { get; set; }
       
        public SelectList SelectAnimal { get; set; }

        public int RazaID { get; set; }
        public SelectList SelectRaza { get; set; }      
             
        public DateTime FechaAlta { get; set; }

        public Usuario Usuario { get; set; }
    }
}