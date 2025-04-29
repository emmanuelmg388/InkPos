using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace InkPos
{
    internal class ProductosDatos
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=emg1234;Database=InkPosDB";

        public List<Productos> BuscarProductos(string criterio, string valor)
        {
            List<Productos> productos = new List<Productos>();
            string columna = (criterio == "ID") ? "p.id_producto::text" : "i.nombre_item";

            string query = $@"
            SELECT p.id_producto, i.nombre_item, p.stock, i.pvp_item, i.porcentaje_iva_item
            FROM productos p
            JOIN items i ON p.id_item = i.id_item
            WHERE {columna} ILIKE @valor";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@valor", "%" + valor + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Productos prod = new Productos
                            {
                                IdProducto = reader.GetInt32(0),
                                NombreItem = reader.GetString(1),
                                Stock = reader.GetInt32(2),
                                Pvp = reader.GetDecimal(3),
                                Iva = reader.GetDecimal(4)
                            };
                            productos.Add(prod);
                        }
                    }
                }
            }

            return productos;
        }
    }
}
