using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorApp4.Shared.Entidades
{
	public class Genero
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="El campos {0} es requerido")]
		public string Nombre { get; set; }
		public List<GeneroPelicula> GeneroPeliculas { get; set; }
	}
}
