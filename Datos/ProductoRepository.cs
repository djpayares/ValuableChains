using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlClient;

namespace Datos
{
    public class ProductoRepository : BaseDatos
    {
        public ProductoRepository() : base()
        {

        }
        public string InsertarPersona(Establecimiento producto)
        {
            if (producto == null)
            {
                return "datos invalidos de la persona";
            }
            string ssql = "INSERT INTO [Producto]([Idproducto],[Diamante],[Rubi],[Zafiro],[Esmeralda])VALUES" +
                $"('{producto.Idproducto}','{producto.Diamante}','{producto.Rubi}','{producto.Zafiro}','{producto.Esmeralda}')";
            SqlCommand cmd = new SqlCommand(ssql, conexion);
            AbrirConexion();
            int i = cmd.ExecuteNonQuery();
            CerrarConexion();
            if (i == 1)
            {
                return $"se guardo la persona --> {producto.Idproducto} ";
            }
            return "datos invalidos de la persona";
        }
        public string EliminarPersona(string cedula)
        {
            string ssql = $"DELETE FROM [dbo].[Producto] WHERE Id='{cedula}'";
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
        public string EditarPersona(Establecimiento producto)
        {
            string ssql = $"UPDATE [dbo].[Producto] SET [Idproducto] = '{producto.Idproducto}', Diamante='{producto.Diamante}',Rubi='{producto.Rubi}',Zafiro='{producto.Zafiro}',Esmeralda='{producto.Esmeralda}' WHERE Idproducto='{producto.Idproducto}'";
            SqlCommand cmd = new SqlCommand(ssql, conexion);
            AbrirConexion();
            var i = cmd.ExecuteNonQuery();
            CerrarConexion();
            if (i >= 1)
            {
                return $"se actualizo la persona con el nombre--> {producto.Idproducto} ";
            }
            return "datos invalidos de la persona";
        }
        public List<Establecimiento> ObtenerTodos()
        {
            List<Establecimiento> list = new List<Establecimiento>();
            string ssql = "select * from Producto";

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
        public string DescontarProducto(Establecimiento producto , string tipoProducto, int cantidadLlevada)
        {
            Console.WriteLine("ENTRO");
            string ssql = "";
            if(tipoProducto == "Diamante")
            {
                if(cantidadLlevada > producto.Diamante)
                {
                    return "LLeva una cantidad mayor a la que hay";
                }
                else
                {

                    ssql = $"UPDATE [dbo].[Producto] SET Diamante='{producto.Diamante - cantidadLlevada}' WHERE Idproducto='{producto.Idproducto}'";
                }
            }

            if (tipoProducto == "Rubi")
            {
                if (cantidadLlevada > producto.Rubi)
                {
                    return "LLeva una cantidad mayor a la que hay";
                }
                else
                {
                     ssql = $"UPDATE [dbo].[Producto] SET Rubi='{producto.Rubi - cantidadLlevada}' WHERE Idproducto='{producto.Idproducto}'";
                }
            }

            if (tipoProducto == "Zafiro")
            {
                if (cantidadLlevada > producto.Zafiro)
                {
                    return "LLeva una cantidad mayor a la que hay";
                }
                else
                {
                     ssql = $"UPDATE [dbo].[Producto] SET Zafiro='{producto.Zafiro - cantidadLlevada}' WHERE Idproducto='{producto.Idproducto}'";
                }
            }
            if (tipoProducto == "Esmeralda")
            {
                if (cantidadLlevada > producto.Esmeralda)
                {
                    return "LLeva una cantidad mayor a la que hay";
                }
                else
                {
                    ssql = $"UPDATE [dbo].[Producto] SET Esmeralda='{producto.Esmeralda - cantidadLlevada}' WHERE Idproducto='{producto.Idproducto}'";
                }
            }

            SqlCommand cmd = new SqlCommand(ssql, conexion);
            AbrirConexion();
            var i = cmd.ExecuteNonQuery();
            CerrarConexion();
            if (i >= 1)
            {
                return $"se actualizo el inventario para el prod --> {producto.Idproducto} ";
            }
            return "datos invalidos del inventario";
        }

        private Establecimiento Mapear(SqlDataReader reader)
        {
            Establecimiento producto = new Establecimiento();


            producto.Idproducto = Convert.ToString(reader["Idproducto"]);
            producto.Diamante = Convert.ToInt32(reader["Diamante"]);
            producto.Rubi = Convert.ToInt32(reader["Rubi"]);
            producto.Zafiro = Convert.ToInt32(reader["Zafiro"]);
            producto.Esmeralda = Convert.ToInt32(reader["Esmeralda"]);


            return producto;
        }
        
        
    }
}
