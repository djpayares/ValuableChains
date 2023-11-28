using Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Contrepository
    {
        string filePath = "Detalles.txt";

        public string GuardarRegistros(Cont cliente)
        {
            var write = new StreamWriter(filePath, true);
            write.WriteLine(cliente.ToString());
            write.Close();
            return $"Registro almacenado";
        }
        public string Guardar(List<Cont> clienteList)
        {
            var write = new StreamWriter(filePath);
            foreach (var i in clienteList)
            {
                write.WriteLine(i.ToString());
            }
            write.Close();
            return $"Datos almacenados";
        }
        public List<Cont> CargarRegistros()
        {
            var clienteList = new List<Cont>();
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
        private Cont Map2(string line)
        {
            var producto = new Cont();
            var datos = line.Split(';');

            producto.ID = (datos[0]);
            producto.Joya = (datos[1]);
            producto.Quilates = double.Parse(datos[2]);
            producto.Valor = double.Parse(datos[3]);

            return producto;

        }

    }
}
