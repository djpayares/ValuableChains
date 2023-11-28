using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.IO;
using Datos;

namespace Logica
{
    public class EstablecimientoService
    {
        ProductoRepository repo = new ProductoRepository();
        public string Actualizar(Establecimiento producto)
        {
            return repo.EditarPersona(producto);
        }

        public string Eliminar(string Idproducto)
        {
            var msg = repo.EliminarPersona(Idproducto);
            return msg;
        }

        public string Insertar(Establecimiento producto)
        {
            var msg = repo.InsertarPersona(producto);
            return msg;
        }

        public List<Establecimiento> ObtenerTodos()
        {
            var msg = repo.ObtenerTodos();
            return msg;
        }

        public string DescontarProducto(Establecimiento producto, string tipoProducto, int cantidadLLevar)
        {
            
            var msg = repo.DescontarProducto(producto, tipoProducto, cantidadLLevar);
            return msg;
        }


    }
}
