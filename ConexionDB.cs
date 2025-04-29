using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace InkPos
{
    internal class ConexionDB
    {
        private string cadenaConexion = "Host=localhost;Port=5432;Username=postgres;Password=emg1234;Database=InkPosDB";

        public NpgsqlConnection ObtenerConexion()
        {
            NpgsqlConnection conexion = new NpgsqlConnection(cadenaConexion);
            try
            {
                conexion.Open(); 
                Console.WriteLine("Conexión exitosa.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de conexión: " + ex.Message);
            }
            return conexion;
        }
    }
}
