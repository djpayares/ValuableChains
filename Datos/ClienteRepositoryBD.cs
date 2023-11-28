using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using Entidad;

namespace Datos
{
    public class ClienteRepositoryBD : BaseDatos
    {
        public ClienteRepositoryBD() : base()
        {

        }
        public string InsertarPersona(Cliente cliente)
        {
            if (cliente == null)
            {
                return "datos invalidos de la persona";
            }
            string ssql = "INSERT INTO [ClienteBD]([Id],[Nombre],[Telefono],[Direccion],[Total])VALUES" +
                $"('{cliente.Id}','{cliente.Name}','{cliente.Telefono}','{cliente.Direccion}','{cliente.Total}')";
            SqlCommand cmd = new SqlCommand(ssql, conexion);
            AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            CerrarConexion();
            if (i == 1)
            {
                return $"se guardo la persona --> {cliente.Name} ";
            }
            return "datos invalidos de la persona";
        }
        public string EliminarPersona(string cedula)
        {
            string ssql = $"DELETE FROM [dbo].[ClienteBD] WHERE Id='{cedula}'";
            SqlCommand cmd = new SqlCommand(ssql, conexion);
            AbrirConexion();
            var i = cmd.ExecuteNonQuery();
            CerrarConexion();
            if (i >= 1)
            {
                return $"se elimino la persona con la cedula--> {cedula} ";
            }
            return "datos invalidos de la persona";
        }
        public string EditarPersona(Cliente cliente)
        {
            string ssql = $"UPDATE [dbo].[ClienteBD] SET [Id] = '{cliente.Id}', Nombre='{cliente.Name}',Telefono='{cliente.Telefono}',Direccion='{cliente.Direccion}',Total='{cliente.Total}' WHERE ID='{cliente.Id}'";
            SqlCommand cmd = new SqlCommand(ssql, conexion);
            AbrirConexion();
            var i = cmd.ExecuteNonQuery();
            CerrarConexion();
            if (i >= 1)
            {
                return $"se actualizo la persona con el nombre--> {cliente.Name} ";
            }
            return "datos invalidos de la persona";
        }
        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> list = new List<Cliente>();
            string ssql = "select * from ClienteBD";

            SqlCommand cmd = new SqlCommand(ssql, conexion);
            AbrirConexion();
            SqlDataReader Rdr = cmd.ExecuteReader();

            while (Rdr.Read())
            {
                list.Add(Mapear(Rdr));
            }
            Rdr.Close();
            CerrarConexion();

            return list;

        }
        private Cliente Mapear(SqlDataReader reader)
        {
            Cliente persona = new Cliente();


            persona.Id = Convert.ToString(reader["Id"]);
            persona.Name = Convert.ToString(reader["Nombre"]);
            persona.Telefono = Convert.ToString(reader["Telefono"]);
            persona.Direccion = Convert.ToString(reader["Direccion"]);
            persona.Total = Convert.ToDouble(reader["Total"]);           

            return persona;
        }
    }
}
