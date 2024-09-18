using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionTarea.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}