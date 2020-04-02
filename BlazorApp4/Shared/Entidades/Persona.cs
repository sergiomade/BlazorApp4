using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlazorApp4.Shared.Entidades
{
	public class Persona
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Biografia { get; set; }
		public string Foto { get; set; }
		[Required]
		public DateTime? FechaNacimiento { get; set; }
		public List<PeliculaActor> PeliculasActor { get; set; }
		[NotMapped]
		public string Personaje { get; set; }

	}
}
