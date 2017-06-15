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
            parametroEspecieId.SqlValue = id;

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

        public static int InsertaEspecie(Especie especieNueva)
        {
            string nombreProcedimiento = "dbo.INSERTA_ESPECIE";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroClasificacion = new SqlParameter();
            parametroClasificacion.ParameterName = "IdClasificacion";
            parametroClasificacion.SqlDbType = SqlDbType.Int;
            parametroClasificacion.SqlValue = especieNueva.clasificacion.idClasificacion;
            cmd.Parameters.Add(parametroClasificacion);

            SqlParameter parametroIdTipoAnimal = new SqlParameter();
            parametroIdTipoAnimal.ParameterName = "IdTipoAnimal";
            parametroIdTipoAnimal.SqlDbType = SqlDbType.Int;
            parametroIdTipoAnimal.SqlValue = especieNueva.tipoAnimal.idTipoAnimal;
            cmd.Parameters.Add(parametroIdTipoAnimal);

            SqlParameter parametroNombre = new SqlParameter();
            parametroNombre.ParameterName = "nombre";
            parametroNombre.SqlDbType = SqlDbType.NVarChar;
            parametroNombre.SqlValue = especieNueva.nombre;
            cmd.Parameters.Add(parametroNombre);

            SqlParameter parametroNPatas = new SqlParameter();
            parametroNPatas.ParameterName = "nPatas";
            parametroNPatas.SqlDbType = SqlDbType.SmallInt;
            parametroNPatas.SqlValue = especieNueva.nPatas;
            cmd.Parameters.Add(parametroNPatas);

            SqlParameter parametroEsMascota = new SqlParameter();
            parametroEsMascota.ParameterName = "esMascota";
            parametroEsMascota.SqlDbType = SqlDbType.Bit;
            parametroEsMascota.SqlValue = especieNueva.esMascota ? 1 : 0;
            cmd.Parameters.Add(parametroEsMascota);

            int numFilasAfectadas = cmd.ExecuteNonQuery();

            return numFilasAfectadas;
        }

        public static int ActualizaEspecie(long id, Especie especie)
        {
            string nombreProcedimiento = "dbo.ACTUALIZA_ESPECIE";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroIdEspecie = new SqlParameter();
            parametroIdEspecie.ParameterName = "IdEspecie";
            parametroIdEspecie.SqlDbType = SqlDbType.BigInt;
            parametroIdEspecie.SqlValue = id;
            cmd.Parameters.Add(parametroIdEspecie);

            SqlParameter parametroClasificacion = new SqlParameter();
            parametroClasificacion.ParameterName = "IdClasificacion";
            parametroClasificacion.SqlDbType = SqlDbType.Int;
            parametroClasificacion.SqlValue = especie.clasificacion.idClasificacion;
            cmd.Parameters.Add(parametroClasificacion);

            SqlParameter parametroIdTipoAnimal = new SqlParameter();
            parametroIdTipoAnimal.ParameterName = "IdTipoAnimal";
            parametroIdTipoAnimal.SqlDbType = SqlDbType.BigInt;
            parametroIdTipoAnimal.SqlValue = especie.tipoAnimal.idTipoAnimal;
            cmd.Parameters.Add(parametroIdTipoAnimal);

            SqlParameter parametroNombre = new SqlParameter();
            parametroNombre.ParameterName = "nombre";
            parametroNombre.SqlDbType = SqlDbType.NVarChar;
            parametroNombre.SqlValue = especie.nombre;
            cmd.Parameters.Add(parametroNombre);

            SqlParameter parametroNPatas = new SqlParameter();
            parametroNPatas.ParameterName = "nPatas";
            parametroNPatas.SqlDbType = SqlDbType.SmallInt;
            parametroNPatas.SqlValue = especie.nPatas;
            cmd.Parameters.Add(parametroNPatas);

            SqlParameter parametroEsMascota = new SqlParameter();
            parametroEsMascota.ParameterName = "esMascota";
            parametroEsMascota.SqlDbType = SqlDbType.Bit;
            parametroEsMascota.SqlValue = especie.esMascota ? 1 : 0;
            cmd.Parameters.Add(parametroEsMascota);

            int numFilasAfectadas = cmd.ExecuteNonQuery();

            return numFilasAfectadas;
        }

        public static int BorraEspecie(long id)
        {
            string nombreProcedimiento = "dbo.BORRAR_ESPECIE";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroIdEspecie = new SqlParameter();
            parametroIdEspecie.ParameterName = "IdEspecie";
            parametroIdEspecie.SqlDbType = SqlDbType.BigInt;
            parametroIdEspecie.SqlValue = id;
            cmd.Parameters.Add(parametroIdEspecie);

            int numFilasAfectadas = cmd.ExecuteNonQuery();
            return numFilasAfectadas;
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
            parametroId.SqlValue = id;

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

        public static int InsertaTipoAnimal(TipoAnimal animal)
        {
            string nombreProcedimiento = "dbo.INSERTA_TIPO_ANIMAL";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroDenominacionTipoAnimal = new SqlParameter();
            parametroDenominacionTipoAnimal.ParameterName = "denominacion";
            parametroDenominacionTipoAnimal.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacionTipoAnimal.SqlValue = animal.denominacion;
            cmd.Parameters.Add(parametroDenominacionTipoAnimal);

            int numFilasAfectadas = cmd.ExecuteNonQuery();

            return numFilasAfectadas;
        }

        public static int ActualizaTipoAnimal(long id, TipoAnimal tipoAnimal)
        {
            string nombreProcedimiento = "dbo.ACTUALIZA_TIPO_ANIMAL";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroIdTipoAnimal = new SqlParameter();
            parametroIdTipoAnimal.ParameterName = "IdTipoAnimal";
            parametroIdTipoAnimal.SqlDbType = SqlDbType.BigInt;
            parametroIdTipoAnimal.SqlValue = id;
            cmd.Parameters.Add(parametroIdTipoAnimal);

            SqlParameter parametroDenominacionTipoAnimal = new SqlParameter();
            parametroDenominacionTipoAnimal.ParameterName = "denominacion";
            parametroDenominacionTipoAnimal.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacionTipoAnimal.SqlValue = tipoAnimal.denominacion;
            cmd.Parameters.Add(parametroDenominacionTipoAnimal);

            int numFilasAfectadas = cmd.ExecuteNonQuery();

            return numFilasAfectadas;
        }

        public static int BorraTipoAnimal(long id)
        {
            string nombreProcedimiento = "dbo.BORRAR_TIPO_ANIMAL";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroIdTipoAnimal= new SqlParameter();
            parametroIdTipoAnimal.ParameterName = "idTipoAnimal";
            parametroIdTipoAnimal.SqlDbType = SqlDbType.BigInt;
            parametroIdTipoAnimal.SqlValue = id;
            cmd.Parameters.Add(parametroIdTipoAnimal);

            int numFilasAfectadas = cmd.ExecuteNonQuery();
            return numFilasAfectadas;
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

        public static int InsertaClasificacion(Clasificacion clasificacion)
        {
            string nombreProcedimiento = "dbo.INSERTA_CLASIFICACION";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroDenominacionClasificacion = new SqlParameter();
            parametroDenominacionClasificacion.ParameterName = "denominacion";
            parametroDenominacionClasificacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacionClasificacion.SqlValue = clasificacion.denominacion;
            cmd.Parameters.Add(parametroDenominacionClasificacion);

            int numFilasAfectadas = cmd.ExecuteNonQuery();

            return numFilasAfectadas;
        }

        public static int ActualizaClasificacion(int id, Clasificacion clasificacion)
        {
            string nombreProcedimiento = "dbo.ACTUALIZA_CLASIFICACION";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroIdClasificacion = new SqlParameter();
            parametroIdClasificacion.ParameterName = "IdClasificacion";
            parametroIdClasificacion.SqlDbType = SqlDbType.Int;
            parametroIdClasificacion.SqlValue = id;
            cmd.Parameters.Add(parametroIdClasificacion);

            SqlParameter parametroDenominacionClasificacion = new SqlParameter();
            parametroDenominacionClasificacion.ParameterName = "denominacion";
            parametroDenominacionClasificacion.SqlDbType = SqlDbType.NVarChar;
            parametroDenominacionClasificacion.SqlValue = clasificacion.denominacion;
            cmd.Parameters.Add(parametroDenominacionClasificacion);

            int numFilasAfectadas = cmd.ExecuteNonQuery();

            return numFilasAfectadas;
        }

        public static int BorraClasificacion(int id)
        {
            string nombreProcedimiento = "dbo.BORRAR_CLASIFICACION";

            SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter parametroIdClasificacion = new SqlParameter();
            parametroIdClasificacion.ParameterName = "IdClasificacion";
            parametroIdClasificacion.SqlDbType = SqlDbType.Int;
            parametroIdClasificacion.SqlValue = id;
            cmd.Parameters.Add(parametroIdClasificacion);

            int numFilasAfectadas = cmd.ExecuteNonQuery();
            return numFilasAfectadas;
        }

    }

}