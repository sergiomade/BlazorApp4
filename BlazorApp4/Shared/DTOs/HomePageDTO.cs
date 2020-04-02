using BlazorApp4.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorApp4.Shared.DTOs
{
	public class HomePageDTO
	{
		public List<Pelicula> PeliculasEnCartelera { get; set; }
		public List<Pelicula> ProximosExtrenos { get; set; }
	}
}
