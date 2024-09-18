using SistemaGestionTarea.Models;
using SistemaGestionTarea.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SistemaGestionTarea.Controllers
{
    [RoutePrefix("api/Tareas")]
    public class TareasController : ApiController
    {
        private readonly ITareaService _tareaService;
        public TareasController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        [HttpGet]
        public IHttpActionResult GetTaskList()
        {
            try
            {
                var result = _tareaService.GetTaskList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("CreateTask")]
        public IHttpActionResult CreateTask([FromBody] Tarea _Tarea)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _tareaService.CreateTask(_Tarea);
                return Created(new Uri(Request.RequestUri + "/" + result.Id), result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("GetTaskById/{id:int}")]
        public IHttpActionResult GetTaskById(int id)
        {
            try
            {
                var result = _tareaService.GetTaskById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("UpdateTask/{id:int}")]
        public IHttpActionResult UpdateTask(int id, [FromBody] Tarea _Tarea)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _tareaService.UpdateTask(id, _Tarea);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

       

        [HttpDelete]
        [Route("DeleteTask/{id:int}")]
        public IHttpActionResult DeleteTask(int id)
        {
            try
            {
                var mensaje = _tareaService.DeleteTask(id)
;
                return Ok(mensaje);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}