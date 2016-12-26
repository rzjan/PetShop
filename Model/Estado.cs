using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Estado
    {
        //PROPIEDADES
        public int EstadoID { get; set; }
        public string EstadoDescripcion { get; set; }

        public virtual ICollection<Mascota> Mascotas { get; set; }
    }
}
