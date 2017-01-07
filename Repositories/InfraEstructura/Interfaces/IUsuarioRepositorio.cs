using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.InfraEstructura.Interfaces
{
    public interface IUsuarioRepositorio: IRepositorioGenerico<Usuario>
    {
        bool RegistrarUsuario(string id, string nombreUsuario, string apUsuario, string correo);

        int GetIDUserByEmail(string email);
    }
}
