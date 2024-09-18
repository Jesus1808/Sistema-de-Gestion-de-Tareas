using SistemaGestionTarea.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaGestionTarea.Services
{
    public class TareaService : ITareaService
    {
        TaskManagerContext bd = new TaskManagerContext();
        public IEnumerable<Tarea> GetTaskList()
        {
            try
            {
                return bd.Tareas.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la obtención de las tareas.", ex);
            }
        }

        public Tarea CreateTask(Tarea _Tarea)
        {
            try
            {
                if (_Tarea == null)
                {
                    throw new ArgumentNullException("No se pudo agregar la tarea");
                }
                else
                {
                    _Tarea.FechaCreacion = DateTime.Now;
                    bd.Tareas.Add(_Tarea);
                    bd.SaveChanges();
                    return _Tarea;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la tarea.", ex);
            }
        }

        public Tarea GetTaskById(int id)
        {
            try
            {
                var tarea = bd.Tareas.Find(id);
                if (tarea == null)
                    throw new KeyNotFoundException($"No se encontró la tarea con el ID {id}.");

                return tarea;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al encontrar la tarea.", ex);
            }
        }
        public Tarea UpdateTask(int id, Tarea _Tarea)
        {
            try
            {
                var result = bd.Tareas.Find(id);
                if (result == null)
                    throw new KeyNotFoundException($"No se encontró la tarea con el ID {id}.");

                result.Titulo = _Tarea.Titulo;
                result.Descripcion = _Tarea.Descripcion;
                result.Estado = _Tarea.Estado;

                bd.Entry(result).State = EntityState.Modified;
                bd.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la tarea.", ex);
            }
        }

       
        public string DeleteTask(int id)
        {
            try
            {
                var result = bd.Tareas.Find(id);
                if (result == null)
                    throw new KeyNotFoundException($"No se encontró la tarea con el ID: {id}.");

                bd.Tareas.Remove(result);
                bd.SaveChanges();

                return $"La tarea fue borrado con exito";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la tarea.", ex);
            }
        }
    }
}