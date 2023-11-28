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
    public class Contservice
    {
        private Contrepository clienteRepository = null;
        private List<Cont> clienteList = null;
        public Contservice()
        {
            clienteRepository = new Contrepository();
            clienteList = clienteRepository.CargarRegistros();

        }

        public String GuardarRegistros(Cont cliente)
        {
            if (cliente.ID == null
                || cliente.Valor == 0)
            {
                return $"Campos nulos";
            }
            var message = (clienteRepository.GuardarRegistros(cliente));
            clienteList = clienteRepository.CargarRegistros();
            return message;
        }
        public List<Cont> CargarRegistros()
        {
            return clienteList;
        }
        public string EliminarRegistro(string idAEliminar)
        {
            try
            {
                var productoAEliminar = clienteList.FirstOrDefault(p => p.ID == idAEliminar);

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

        public Cont BuscarPotId(string id)
        {
            foreach (var item in clienteList)
            {
                if (id == item.ID)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Cont> ConsultarTodos()
        {
            return clienteList;
        }
        public List<Cont> ConsultarFiltrado(string filtro)
        {
            if (filtro == "")
            {
                return clienteList;
            }
            List<Cont> lista = new List<Cont>();
            foreach (var item in clienteList)
            {
                if (item.Joya.Contains(filtro) || item.ID.StartsWith(filtro))
                {
                    lista.Add(item);
                }
            }
            return lista;
        }
        Contrepository repo = new Contrepository();
        public List<Cont> ObtenerTodos()
        {
            var msg = repo.CargarRegistros();
            return msg;
        }

    }
}
