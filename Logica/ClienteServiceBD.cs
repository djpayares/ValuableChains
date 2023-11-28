using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ClienteServiceBD : ICrud
    {
        ClienteRepositoryBD repo = new ClienteRepositoryBD();
        public string Actualizar(Cliente cliente)
        {
            return repo.EditarPersona(cliente);
        }

        public string Eliminar(string id)
        {
            var msg = repo.EliminarPersona(id);
            return msg;
        }

        public string Insertar(Cliente persona)
        {
            var msg = repo.InsertarPersona(persona);
            return msg;
        }

        public List<Cliente> ObtenerTodos()
        {
            var msg = repo.ObtenerTodos();
            return msg;
        }
    }
}
