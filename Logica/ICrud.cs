using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Logica
{
    public interface ICrud
    {
        string Insertar(Cliente persona);
        string Eliminar(string id);
        string Actualizar(Cliente persona);
        List<Cliente> ObtenerTodos();
    }
}
