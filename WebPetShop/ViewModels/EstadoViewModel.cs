
using System.ComponentModel.DataAnnotations;
namespace WebPetShop.ViewModels
{
    public class EstadoViewModel
    {
        [Key]
        public int EstadoID { get; set; }
        [Display(Name="Estado")]
        public string EstadoDescripcion { get; set; }
    }
}