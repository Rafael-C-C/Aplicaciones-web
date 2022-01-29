using System;
using System.Collections.Generic;

#nullable disable

namespace WebServicesDSM.Models
{
    public partial class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public int Rating { get; set; }
        public DateTime Año { get; set; }
    }
}
