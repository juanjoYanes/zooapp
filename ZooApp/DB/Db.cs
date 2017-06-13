using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ZooApp
{
    public static class Db
    {
        static SqlConnection conexion = null;
        public static void Conectar()
        {
            try
            {
                string cadenaConexion = @"Server=.\sqlexpress; 
                                          Database=zoodb;
                                          User Id=testuser;
                                          Password=!Curso@2017;";

                conexion = new SqlConnection();
                conexion.ConnectionString = cadenaConexion;

                conexion.Open();
            }
            catch (Exception)
            {
                if (conexion != null)
                {
                    if (conexion.State != ConnectionState.Closed)
                    {
                        conexion.Close();
                    }
                    conexion.Dispose();
                    conexion = null;
                }
            }
        }

        public static bool EstaLaConexionAbierta()
        {
            return conexion.State == ConnectionState.Open;
        }

        public static void Desconectar()
        {
            if (conexion != null)
            {
                if (conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
        }

        public static List<TipoAnimal> SeleccionarTiposAnimales()
        {
            List<TipoAnimal> resultado = new List<TipoAnimal>();

            string nombreProcedimiento = "dbo.GET_TIPOS_ANIMALES";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TipoAnimal tipoAnimal = new TipoAnimal();
                tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                tipoAnimal.denominacion = reader["denominacion"].ToString();

                resultado.Add(tipoAnimal);
            }
            return resultado;
        }

        public static List<TipoAnimal> SeleccionarTipoAnimal(long id)
        {
            List<TipoAnimal> resultado = new List<TipoAnimal>();

            string nombreProcedimiento = "dbo.GET_TIPO_ANIMAL";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idTipoAnimal";
            parametroId.SqlDbType = SqlDbType.BigInt;
            parametroId.Value = id;

            cmd.Parameters.Add(parametroId);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TipoAnimal tipoAnimal = new TipoAnimal();
                tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                tipoAnimal.denominacion = reader["denominacion"].ToString();
                resultado.Add(tipoAnimal);
            }
            return resultado;
        }

        public static List<Clasificacion> SeleccionarClasificaciones()
        {
            List<Clasificacion> resultado = new List<Clasificacion>();

            string nombreProcedimiento = "dbo.GET_CLASIFICACIONES";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Clasificacion Clasificacion = new Clasificacion();
                Clasificacion.idClasificacion = (int)reader["idClasificacion"];
                Clasificacion.denominacion = reader["denominacion"].ToString();

                resultado.Add(Clasificacion);
            }
            return resultado;
        }

        public static List<Clasificacion> SeleccionarClasificacion(int id)
        {
            List<Clasificacion> resultado = new List<Clasificacion>();

            string nombreProcedimiento = "dbo.GET_CLASIFICACION";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroId = new SqlParameter();
            parametroId.ParameterName = "idClasificacion";
            parametroId.SqlDbType = SqlDbType.SmallInt;
            parametroId.Value = id;

            cmd.Parameters.Add(parametroId);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Clasificacion Clasificacion = new Clasificacion();
                Clasificacion.idClasificacion = (int)reader["idClasificacion"];
                Clasificacion.denominacion = reader["denominacion"].ToString();
                resultado.Add(Clasificacion);
            }
            return resultado;
        }

        public static List<Especie> SeleccionarEspecies()
        {
            List<Especie> resultados = new List<Especie>();

            string nombreProcedimiento = "dbo.GET_ESPECIES";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Especie especie = new Especie();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];

                especie.tipoAnimal = new TipoAnimal();
                especie.tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                especie.tipoAnimal.denominacion = reader["denominacionTipoAnimal"].ToString();

                especie.clasificacion = new Clasificacion();
                especie.clasificacion.idClasificacion = (int)reader["IdClasificacion"];
                especie.clasificacion.denominacion = reader["denominacionClasificacion"].ToString();

                resultados.Add(especie);
            }
            

            return resultados;
        }

        public static List<Especie> SeleccionarEspecie(long id)
        {
            List<Especie> resultados = new List<Especie>();

            string nombreProcedimiento = "dbo.GET_ESPECIE";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroEspecieId = new SqlParameter();
            parametroEspecieId.ParameterName = "idEspecie";
            parametroEspecieId.SqlDbType = SqlDbType.BigInt;
            parametroEspecieId.Value = id;

            cmd.Parameters.Add(parametroEspecieId);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Especie especie = new Especie();
                especie.idEspecie = (long)reader["idEspecie"];
                especie.nombre = reader["nombre"].ToString();
                especie.nPatas = (short)reader["nPatas"];
                especie.esMascota = (bool)reader["esMascota"];

                especie.tipoAnimal = new TipoAnimal();
                especie.tipoAnimal.idTipoAnimal = (long)reader["idTipoAnimal"];
                especie.tipoAnimal.denominacion = reader["denominacionTipoAnimal"].ToString();

                especie.clasificacion = new Clasificacion();
                especie.clasificacion.idClasificacion = (int)reader["IdClasificacion"];
                especie.clasificacion.denominacion = reader["denominacionClasificacion"].ToString();

                resultados.Add(especie);
            }

            return resultados;
        }
    }

}