using SistemaGestionTarea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionTarea.Services
{
    public interface ITareaService
    {
        IEnumerable<Tarea> GetTaskList();
        Tarea CreateTask(Tarea _Tarea);
        Tarea UpdateTask(int id, Tarea tarea);
        string DeleteTask(int id);
        Tarea GetTaskById(int id);
    }
}
