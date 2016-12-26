using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Animal
    {
        //PROPIEDADES
        public int AnimalID { get; set; }
        public string Descripccion { get; set; }

        public string FotoDefault { get; set; }

        //public virtual ICollection<Mascota> mascotas { get; set; }

        public virtual ICollection<Raza> Razas { get; set; }

        //METODOS
    }
}
