﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProductoCLS
    {
		public int IdProducto { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public MarcaCLS oMarca { get; set; }
		public CategoriaCLS oCategoria { get; set; }
		public decimal Precio { get; set; }
		public string PrecioTexto { get; set; }
		public int Stock { get; set; }
		public string RutaImagen { get; set; }
		public string NombreImagen { get; set; }
		public bool Activo { get; set; }
		public string Base64 { get; set; }
		public string Extencion { get; set; }
	}
}
