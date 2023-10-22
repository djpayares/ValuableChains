using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClienteRepository
    {
        string filePath = "CLIENTES.txt";

        public string GuardarRegistros(Cliente cliente)
        {
            var write = new StreamWriter(filePath, true);
            write.WriteLine(cliente.ToString());
            write.Close();
            return $"Registro almacenado";
        }
        public string Guardar(List<Cliente> clienteList)
        {
            var write = new StreamWriter(filePath);
            foreach (var i in clienteList)
            {
                write.WriteLine(i.ToString());
            }
            write.Close();
            return $"Datos almacenados";
        }
        public List<Cliente> CargarRegistros()
        {
            var clienteList = new List<Cliente>();
            try
            {
                StreamReader reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    clienteList.Add(Map2(reader.ReadLine()));
                }
                reader.Close();
                return clienteList;
            }
            catch (IOException)
            {
                return null;
            }
        }
        private Cliente Map2(string line)
        {
            var producto = new Cliente();
            var datos = line.Split(';');

            producto.Id = (datos[0]);
            producto.Name = (datos[1]);
            producto.Total = double.Parse(datos[2]);
            
            return producto;

        }
    }
}
