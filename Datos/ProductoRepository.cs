using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.IO;
using System.Runtime.Remoting.Messaging;


namespace Datos
{
    public class ProductoRepository
    {
        string filePath = "INVENTARIO.txt";

        public string GuardarRegistros(Establecimiento establecimiento)
        {
            var write = new StreamWriter(filePath, true);
            write.WriteLine(establecimiento.ToString());
            write.Close();
            return $"Registro almacenado";
        }
        public string Guardar(List<Establecimiento> establecimientoList)
        {
            var write = new StreamWriter(filePath);
            foreach (var i in establecimientoList)
            {
                write.WriteLine(i.ToString());
            }
            write.Close();
            return $"Datos almacenados";
        }
        public List<Establecimiento> CargarRegistros()
        {
            var establecimientoList = new List<Establecimiento>();
            try
            {
                StreamReader reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    establecimientoList.Add(Map(reader.ReadLine()));
                }
                reader.Close();
                return establecimientoList;
            }
            catch (IOException)
            {
                return null;
            }
        }
        private Establecimiento Map(string line)
        {
            var producto = new Establecimiento();
            var datos = line.Split(';');

            producto.Diamante = int.Parse(datos[0]);
            producto.Rubi = int.Parse(datos[1]);
            producto.Zafiro = int.Parse(datos[2]);
            producto.Esmeralda = int.Parse(datos[3]);          
            return producto;

        }
    }
}
