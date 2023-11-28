using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface ICrudP
    {
        string Insertar(Establecimiento producto);
        string Eliminar(string id);
        string Actualizar(Establecimiento producto);
        List<Cliente> ObtenerTodos();
    }
}
