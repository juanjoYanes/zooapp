using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class TipoAnimalController : ApiController
    {
        // GET: api/TipoAnimal
        public RespuestaAPI<TipoAnimal> Get()
        {
            RespuestaAPI<TipoAnimal> resultado = new RespuestaAPI<TipoAnimal>();
            List<TipoAnimal> listaAnimales = new List<TipoAnimal>();
            
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    listaAnimales = Db.SeleccionarTiposAnimales();
                    resultado.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception)
            {
                resultado.error = "Se ha producido un error.";
            }
            resultado.totalElementos = listaAnimales.Count;
            resultado.data = listaAnimales;
            return resultado;

        }

        // GET: api/TipoAnimal/5
        public RespuestaAPI<TipoAnimal> Get(long id)
        {
            RespuestaAPI<TipoAnimal> resultado = new RespuestaAPI<TipoAnimal>();
            List<TipoAnimal> listaAnimales = new List<TipoAnimal>();
            
            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    listaAnimales = Db.SeleccionarTipoAnimal(id);
                    resultado.error = "";
                }
                Db.Desconectar();
            }
            catch (Exception)
            {
                resultado.error = "Se ha producido un error.";
            }
            resultado.totalElementos = listaAnimales.Count;
            resultado.data = listaAnimales;
            return resultado;
        }

        // POST: api/TipoAnimal
        [HttpPost]
        public IHttpActionResult Post([FromBody]TipoAnimal tipoAnimalNuevo)
        {
            RespuestaAPI<TipoAnimal> resultado = new RespuestaAPI<TipoAnimal>();
            return Ok(resultado);
        }

        // PUT: api/TipoAnimal/5
        [HttpPut]
        public IHttpActionResult Put(long id, [FromBody]TipoAnimal tipoAnimal)
        {
            RespuestaAPI<TipoAnimal> resultado = new RespuestaAPI<TipoAnimal>();

            return Ok(resultado);
        }

        // DELETE: api/TipoAnimal/5
        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            RespuestaAPI<TipoAnimal> resultado = new RespuestaAPI<TipoAnimal>();
            return Ok(resultado);
        }
    }
}
