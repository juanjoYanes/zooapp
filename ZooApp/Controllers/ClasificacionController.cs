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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clasificacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clasificacion/5
        public void Delete(int id)
        {
        }
    }
}
