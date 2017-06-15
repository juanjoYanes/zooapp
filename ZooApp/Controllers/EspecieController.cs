using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class EspecieController : ApiController
    {
        // GET: api/Especie
        public RespuestaAPI<Especie> Get()
        {
            RespuestaAPI<Especie> resultados = new RespuestaAPI<Especie>();
            List<Especie> listaEspecies = new List<Especie>();

            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaEspecies = Db.SeleccionarEspecies();
                    resultados.error = "";
                }

                Db.Desconectar();
            }
            catch (Exception)
            {
                resultados.error = "Se ha producido un error en la consulta";
            }
            resultados.data = listaEspecies;
            resultados.totalElementos = listaEspecies.Count;
            return resultados;
        }

        // GET: api/Especie/5
        public RespuestaAPI<Especie> Get(long id)
        {
            RespuestaAPI<Especie> resultados = new RespuestaAPI<Especie>();
            List<Especie> listaEspecies = new List<Especie>();

            try
            {
                Db.Conectar();

                if (Db.EstaLaConexionAbierta())
                {
                    listaEspecies = Db.SeleccionarEspecie(id);
                    resultados.error = "";
                }

                Db.Desconectar();
            }
            catch (Exception)
            {
                resultados.error = "Se ha producido un error en la consulta";
            }
            resultados.data = listaEspecies;
            resultados.totalElementos = listaEspecies.Count;
            return resultados;
        }

        // POST: api/Especie
        [HttpPost]
        public IHttpActionResult Post([FromBody]Especie nuevaEspecie)
        {
            RespuestaAPI<Especie> respuesta = new RespuestaAPI<Especie>();
            respuesta.error = "";
            int numFilasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    numFilasAfectadas = Db.InsertaEspecie(nuevaEspecie);
                }
                respuesta.totalElementos = numFilasAfectadas;
                Db.Desconectar();
            }
            catch (Exception)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Se ha producido un error al insertar una 'Especie' nueva";
            }
            return Ok(respuesta);
        }

        // PUT: api/Especie/5
        [HttpPut]
        public IHttpActionResult Put(long id, [FromBody]Especie especie)
        {
            RespuestaAPI<Especie> respuesta = new RespuestaAPI<Especie>();
            respuesta.error = "";
            int numFilasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    numFilasAfectadas = Db.ActualizaEspecie(id, especie);
                }
                respuesta.totalElementos = numFilasAfectadas;
                Db.Desconectar();
            }
            catch (Exception)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Se ha producido un error al actualizar una 'Especie'";
            }
            return Ok(respuesta);
        }

        // DELETE: api/Especie/5
        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            RespuestaAPI<Especie> respuesta = new RespuestaAPI<Especie>();
            respuesta.error = "";
            int numFilasAfectadas = 0;

            try
            {
                Db.Conectar();
                if (Db.EstaLaConexionAbierta())
                {
                    numFilasAfectadas = Db.BorraEspecie(id);
                }
                respuesta.totalElementos = numFilasAfectadas;
                Db.Desconectar();
            }
            catch (Exception e)
            {
                respuesta.totalElementos = 0;
                respuesta.error = "Se ha producido un error al Borrar una 'Especie'";
            }
            return Ok(respuesta);
        }
    }
}
