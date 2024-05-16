using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokinVarausApp.Models
{
    public class Lasku
    {
        public int lasku_Id { get; set; }
        public int varaus_Id { get; set; }
        public double summa {  get; set; }
        public double alv { get; set; }
        public int maksettu { get; set; }
    }
}