using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InkPos
{
    public partial class FormPruebaDB : Form
    {
        public FormPruebaDB()
        {
            InitializeComponent();
        }

        private void FormPruebaDB_Load(object sender, EventArgs e)
        {
            ConexionDB conexion = new ConexionDB();
            var conn = conexion.ObtenerConexion();

            if (conn.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Conexión exitosa a la base de datos.");
                conn.Close(); // Siempre cerrar después de usar la conexión
            }
            else
            {
                MessageBox.Show("Error de conexión.");
            }
        }
    }
}
