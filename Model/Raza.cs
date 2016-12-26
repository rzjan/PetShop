using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Raza
    {
        public int RazaID { get; set; }
        public string DescripcionRaza { get; set; }

        public virtual ICollection<Animal> Mascotas { get; set; }

    }
}
