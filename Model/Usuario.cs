using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Usuario
    {
        //PROPIEDADES
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string Direccion  { get; set; }
        public string Telefono { get; set; }

        public string Email { get; set; }


        public virtual ICollection<Mascota> Mascotas{ get; set; }


        //METODOS
    }
}
