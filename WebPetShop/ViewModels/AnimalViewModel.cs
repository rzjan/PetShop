

using System.ComponentModel.DataAnnotations;
namespace WebPetShop.ViewModels
{
    public class AnimalViewModel
    {
        //PROPIEDADES
       
        public int AnimalID { get; set; }
        public string Descripcion { get; set; }

        public string FotoDefault { get; set; }

        //public virtual ICollection<Mascota> mascotas { get; set; }

        //public virtual ICollection<Raza> Razas { get; set; }

        //METODOS
    }
}