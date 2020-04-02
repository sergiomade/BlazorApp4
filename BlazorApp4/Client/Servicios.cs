using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Client
{
	public class Servicios
	{
		public class ServicioSingleton
		{
			public int Valor { get; set; }
		}

		public class ServicioTransient
		{
			public int Valor { get; set; }
		}

	}
}
