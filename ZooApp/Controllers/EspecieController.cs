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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Especie/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Especie/5
        public void Delete(int id)
        {
        }
    }
}
