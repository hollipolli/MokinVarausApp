using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokinVarausApp.Models
{
	public class Palvelu
	{
		public int palvelu_Id { get; set; }
		public int alue_Id { get; set; }
		public string nimi {  get; set; }
		public string kuvaus { get; set; }
		public double hinta { get; set; }
		public double alv { get; set; }

	}
}