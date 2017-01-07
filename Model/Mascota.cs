using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;


namespace Model
{
    public class Mascota
    {
        //PROPIEDADES     
        public int MascotaID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }         
             
       
        [Display(Name="Fecha de Nacimiento")]
        [DataType(DataType.Date)]     
        [Required(ErrorMessage = "Debe ingresar fecha de nacimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaNacimiento { get; set; }
        //public string FecNac { get; set; }
        [Display(Name="Estado")]
        public int EstadoID { get; set; }
        //public string ImageMimeType { get; set; }
        public string nEstado { get; set; }
        
        [MinLength(2)]
        [MaxLength(120)]        
        public string Foto { get; set; }
        public int AnimalID { get; set; }              
        public int RazaID { get; set; }
        public int UsuarioID { get; set; }

        
        public DateTime FechaAlta { get; set; }       
        
        
        public virtual Animal Animal { get; set; }
        public virtual Raza Raza { get; set; }


        //[NotMapped]
        //public SelectList SelectAnimal { get; set; }
        //[NotMapped]
        //public SelectList SelectRaza { get; set; }
        //[NotMapped]
        //public SelectList SelectEstado { get; set; }


    }

}
