using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPetShop.ViewModels
{
    [Serializable]
    public class MascotaViewModel
    {
        //PROPIEDADES
        //[Key]
        public int MascotaID { get; set; }

        [Required(ErrorMessage="Este campo es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int Edad { get; set; }
       
        
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Debe ingresar fecha de nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }       


        [Required(ErrorMessage = "Este campo es requerido")]
        [Display(Name="Estado")]
        public int EstadoID { get; set; }
        public string nEstado { get; set; }
        [NotMapped]
        public SelectList SelectEstado { get; set; }
        public string Foto { get; set; }


        [Display(Name = "Foto")]
        public HttpPostedFileBase imagen { get; set; }

        [Display(Name = "Tipo Animal")]
        public int AnimalID { get; set; }
        [NotMapped]
        public SelectList SelectAnimal { get; set; }

        [Display(Name="Raza")]
        public int RazaID { get; set; }
        [NotMapped]    
        public SelectList SelectRaza { get; set; }

        [Display(Name = "Dueño")]
        public int UsuarioID { get; set; }      
        
        [DataType(DataType.Date)]
        public DateTime FechaAlta { get; set; }         
    }        
           
           
}