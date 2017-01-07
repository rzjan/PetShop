

using System.ComponentModel.DataAnnotations;
namespace WebPetShop.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}