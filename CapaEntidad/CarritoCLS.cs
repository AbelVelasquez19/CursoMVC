using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CarritoCLS
    {
        public int IdCarrito { get; set; }
        public ClienteCLS oCliente{ get; set; }
        public ProductoCLS oProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
