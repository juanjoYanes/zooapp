using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class ClasificacionController : ApiController
    {
        // GET: api/Clasificacion
        public RespuestaAPI<Clasificacion> Get()
        {
            RespuestaAPI<Clasificacion> resultado = new RespuestaAPI<Clasificacion>();
            List<Clasificacion> listaClasificaciones = new List<Clasificacion>();
            
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    listaClasificaciones = Db.SeleccionarClasificaciones();
                    resultado.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception)
            {
                resultado.error = "Se ha producido un error.";
            }
            resultado.totalElementos = listaClasificaciones.Count;
            resultado.data = listaClasificaciones;
            return resultado;
        }

        // GET: api/Clasificacion/5
        public RespuestaAPI<Clasificacion> Get (int id)
        {
            RespuestaAPI<Clasificacion> resultado = new RespuestaAPI<Clasificacion>();
            List<Clasificacion> listaClasificaciones = new List<Clasificacion>();
            
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    listaClasificaciones = Db.SeleccionarClasificacion(id);
                    resultado.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception)
            {
                resultado.error = "Se ha producido un error en la consulta sobre la tabla Clasificaciones.";
            }
            resultado.totalElementos = listaClasificaciones.Count;
            resultado.data = listaClasificaciones;
            return resultado;
        }

        // POST: api/Clasificacion
        [HttpPost]
        public IHttpActionResult Post([FromBody]Clasificacion nuevaClasificacion)
        {
            RespuestaAPI<Clasificacion> respuesta = new RespuestaAPI<Clasificacion>();
            respuesta.error = "";
            int numFilasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    numFilasAfectadas = Db.InsertaClasificacion(nuevaClasificacion);
                }
                respuesta.totalElementos = numFilasAfectadas;
                Db.Desconectar();
            }
            catch (Exception)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Se ha producido un error al insertar una nueva Clasificacion";
            }
            return Ok(respuesta);
        }

        // PUT: api/Clasificacion/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]Clasificacion clasificacion)
        {
            RespuestaAPI<Clasificacion> respuesta = new RespuestaAPI<Clasificacion>();
            respuesta.error = "";
            int numFilasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    numFilasAfectadas = Db.ActualizaClasificacion(id, clasificacion);
                }
                respuesta.totalElementos = numFilasAfectadas;
                Db.Desconectar();
            }
            catch (Exception)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Se ha producido un error al actualizar una Clasificacion.";
            }
            return Ok(respuesta);
        }
        [HttpDelete]
        // DELETE: api/Clasificacion/5
        public IHttpActionResult Delete(int id)
        {
            RespuestaAPI<Clasificacion> respuesta = new RespuestaAPI<Clasificacion>();
            respuesta.error = "";
            int numFilasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    numFilasAfectadas = Db.BorraClasificacion(id);
                }
                respuesta.totalElementos = numFilasAfectadas;
                Db.Desconectar();
            }
            catch (Exception)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Se ha producido un error al borrar una Clasificacion";
            }
            return Ok(respuesta);
        }
    }
}
