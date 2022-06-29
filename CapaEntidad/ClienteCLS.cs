using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClienteCLS
    {
		public int IdCliente { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Correo { get; set; }
		public string Clave { get; set; }
		public bool Restablecer { get; set; }
	}
}
