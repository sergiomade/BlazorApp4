﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp4.Shared.Entidades
{
	public class Pelicula
	{
		public int Id { get; set; }
		[Required]
		public string Titulo { get; set; }
		public string Resumen { get; set; }
		public bool  EnCartelera { get; set; }
		public string Trailer { get; set; }
		[Required]
		public DateTime? Lanzamiento { get; set; }
		public string Poster { get; set; }
		public List<GeneroPelicula> GenerosPelicula { get; set; } = new List<GeneroPelicula>();
		public List<PeliculaActor> PeliculasActor { get; set; }
		public string  TituloCortado {
			get 
			{

				if ( string.IsNullOrWhiteSpace(Titulo) )
				{
					return null;
				}
				
				if (Titulo.Length > 60)
				{
					return Titulo.Substring(0, 60) + "...";
				}
				else
				{
					return Titulo;
				}
			}
		}
	}
}
