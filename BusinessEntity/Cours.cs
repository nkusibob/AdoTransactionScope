using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public  class Cours
    {
        public string code { get; set; }
        public string libellé { get; set; }
        public string IdCours { get; set; }
        public DateTime last_modified { get; set; }
    }
}
