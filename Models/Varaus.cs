using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokinVarausApp.Models
{
    public class Varaus
    {
        public int varaus_Id { get; set; }
        public int asiakas_Id { get; set; }
        public int mokki_Id { get; set; }
        public DateTime varattu_pvm { get; set; }
        public DateTime vahvistus_pvm { get; set; }
        public DateTime varattu_alkupvm { get; set; }
        public DateTime varattu_loppupvm { get; set; }
    }
}