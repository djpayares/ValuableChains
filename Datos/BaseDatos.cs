using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class BaseDatos
    {
        protected SqlConnection conexion;      
        protected string cadenaConexion = "Server=DESKTOP-MOJC7BE;Database=ValuableChainBD;Trusted_Connection=True;";
        public BaseDatos()
        {
            conexion = new SqlConnection(cadenaConexion);
        }
       

        public void AbrirConexion()
        {         
            conexion.Open();
        }
        public void CerrarConexion()
        {
            conexion.Close();
        }

        public string Cadena()
        {
            return conexion.ConnectionString;
        }
    }
}
