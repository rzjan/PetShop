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
        
        //public int AnimalID { get; set; }

      
        //public virtual Animal Animal { get; set; }
        public virtual ICollection<Mascota> Mascota { get; set; }

    }
}
