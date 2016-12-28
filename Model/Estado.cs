using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    //public class Estado
    //{
    //    //PROPIEDADES
    //    public int EstadoID { get; set; }
    //    public string EstadoDescripcion { get; set; }

    //    public virtual ICollection<Mascota> Mascotas { get; set; }
    //}
    public enum Estado
    {
        //PROPIEDADES
        Para_adopcion = 1,
        A_la_venta = 2,
        Adoptada = 3,
        Vendida = 4          
    }    
}
