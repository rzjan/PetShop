using Model;
using System.Collections.Generic;

namespace Repositories.InfraEstructura.Interfaces
{
    public interface IMascotaRepositorio : IRepositorioGenerico<Mascota>
    {
        IEnumerable<Mascota> GetAllByUser(int _userId);
        IEnumerable<Mascota> GetAllByAnimal(int _animalId);
        IEnumerable<Mascota> GetAllByAdoptSales();
        IEnumerable<Mascota> GetAllByNotAdoptSales();
        IEnumerable<Mascota> GetLastMascotasRegistered();
    }
}
