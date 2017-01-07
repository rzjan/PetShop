using Model;
using Repositories.InfraEstructura;
using Repositories.InfraEstructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositorios
{
    public class UsuarioRepositorio: RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {
        private PetShopContext _context = new PetShopContext();

        public bool RegistrarUsuario(string id, string nUsuario, string ApUsuario, string correo) {

            Usuario usu = new Usuario();
            usu.Direccion = id;
            usu.NombreUsuario = nUsuario;
            usu.ApellidoUsuario = ApUsuario;
            usu.Email = correo;
            Add(usu);
            return true;        
        }

        public int GetIDUserByEmail(string email)
        {
           var _usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

           return _usuario.UsuarioID;
        
        }
        

    }
}
 