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
    public class MascotaRepositorio: RepositorioGenerico<Mascota>, IMascotaRepositorio
    {
        private PetShopContext _context = new PetShopContext();
        
        /// <summary>
        /// Obtener listado de mascotas por usuarios
        /// </summary>
        /// <param name="_userId"></param>
        /// <returns></returns>
        public IEnumerable<Mascota> GetAllByUser(int _userId)
        {                                
            var query = from p in _context.Mascotas
                        where p.UsuarioID == _userId
                        select p;                
            return query;
        }        
        /// <summary>
        /// Filtro de mascotas por tipo de Animal
        /// </summary>
        /// <param name="_animalId"></param>
        /// <returns></returns>
        public IEnumerable<Mascota> GetAllByAnimal(int _animalId)
        {
            var query = from p in _context.Mascotas
                        where p.AnimalID == _animalId
                        select p;
            return query;
        }        
        /// <summary>
        /// Obtener listado de mascotas vendidas y/o Adoptadas 
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public IEnumerable<Mascota> GetAllByAdoptSales()
        {
            var query = from m in _context.Mascotas                        
                        where m.nEstado =="Adoptada" ||
                              m.nEstado =="Vendida"
                        select m;
            return query;           
        }        
        /// <summary>
        /// Obtener listado de mascotas NO vendidas y/o Adoptadas
        /// </summary>
        /// <param name=></param>
        /// <returns></returns>
        public IEnumerable<Mascota> GetAllByNotAdoptSales()
        {
            var query = from m in _context.Mascotas
                        where m.nEstado != "Adoptada" &&
                              m.nEstado != "Vendida"
                        select m;
            return query;
        }

        public IEnumerable<Mascota> GetLastMascotasRegistered()
        {
            var query = (from m in _context.Mascotas                        
                        select m).Take(5).OrderByDescending(m => m.FechaAlta);
            return query;

            //var result_evento = (from ev in db.T_CRM_Evento
            //                     where ev.DE_CNPJ == carregagrid.Cnpj
            //                     select new
            //                     {
            //                         ev.ID_CRM_Evento,
            //                         ev.DE_Usuario,
            //                         ev.ID_TipoEvento,
            //                         ev.DT_Inclusao
            //                     }).Take(5).OrderByDescending(dt => dt.DT_Inclusao);
        }        

    }
    
}

