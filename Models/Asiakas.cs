using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokinVarausApp.Models
{
    public class Asiakas
    {
        public int asiakas_Id { get; set; }
        public char postinro {  get; set; }
        public string etunimi { get; set; }
        public string sukunimi { get; set; }
        public string lahiosoite { get; set; }
        public string email { get; set; }
        public string puhelinnro { get; set; }
    }
}