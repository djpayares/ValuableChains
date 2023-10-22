using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ClienteService
    {

        private ClienteRepository clienteRepository = null;
        private List<Cliente> clienteList = null;
        public ClienteService()
        {
            clienteRepository = new ClienteRepository();
            clienteList = clienteRepository.CargarRegistros();

        }

        public String GuardarRegistros(Cliente cliente)
        {
            if (cliente.Id == null 
                || cliente.Total == 0)
            {
                return $"Campos nulos";
            }
            var message = (clienteRepository.GuardarRegistros(cliente));
            clienteList = clienteRepository.CargarRegistros();
            return message;
        }
        public List<Cliente> CargarRegistros()
        {
            return clienteList;
        }
        public string EliminarRegistro(string idAEliminar)
        {
            try
            {
                var productoAEliminar = clienteList.FirstOrDefault(p => p.Id == idAEliminar);

                if (productoAEliminar != null)
                {
                    clienteList.Remove(productoAEliminar);
                    clienteRepository.Guardar(clienteList);
                    return "Registro eliminado con éxito.";
                }
                else
                {
                    return "No se encontró un registro con el ID proporcionado.";
                }
            }
            catch (IOException)
            {
                return "Ocurrió un error al intentar eliminar el registro.";
            }
        }

        public Cliente BuscarPotId(string id)
        {
            foreach (var item in clienteList)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Cliente> ConsultarTodos()
        {
            return clienteList;
        }
        public List<Cliente> ConsultarFiltrado(string filtro)
        {
            if (filtro == "")
            {
                return clienteList;
            }
            List<Cliente> lista = new List<Cliente>();
            foreach (var item in clienteList)
            {
                if (item.Name.Contains(filtro) || item.Id.StartsWith(filtro))
                {
                    lista.Add(item);
                }
            }
            return lista;
        }
    }
}
