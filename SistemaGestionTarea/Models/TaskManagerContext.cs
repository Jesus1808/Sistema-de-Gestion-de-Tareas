using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGestionTarea.Models
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext() : base("TaskManagerContext")
        {

        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}