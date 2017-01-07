
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Model
{
    public class Estado
    {
        //    //PROPIEDADES
        [Key]
        public int EstadoID { get; set; }
        public string EstadoDescripcion { get; set; }

        //public IEnumerable<SelectListItem> EstadoList { get; set; }

    //    public virtual ICollection<Mascota> Mascotas { get; set; }
    }
    
    
}
