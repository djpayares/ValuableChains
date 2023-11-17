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
        private ProductoRepository productoRepository = null;
        private List<Establecimiento> establecimientoList = null;
        public EstablecimientoService()
        {
            productoRepository = new ProductoRepository();
            establecimientoList = productoRepository.CargarRegistros();

        }
        public string EliminarRegistro(int idAEliminar)
        {
            try
            {
                var productoAEliminar = establecimientoList.FirstOrDefault(p => p.Diamante == idAEliminar);

                if (productoAEliminar != null)
                {
                    establecimientoList.Remove(productoAEliminar);
                    productoRepository.Guardar(establecimientoList);
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
        public Establecimiento BuscarPotId(int id)
        {
            foreach (var item in establecimientoList)
            {
                if (id == item.Diamante)
                {
                    return item;
                }
            }
            return null;
        }
        public List<Establecimiento> ConsultarTodos()
        {
            return establecimientoList;
        }

        public String GuardarRegistros(Establecimiento establecimiento)
        {
            if (establecimiento.Diamante == 0 )
            { 
                establecimiento.Diamante = 0;               
            }
            if (establecimiento.Rubi == 0)
            {
                establecimiento.Rubi = 0;
            }
            if (establecimiento.Zafiro == 0)
            {
                establecimiento.Zafiro = 0;
            }
            if (establecimiento.Esmeralda == 0)
            {
                establecimiento.Esmeralda = 0;
            }

            var message = (productoRepository.GuardarRegistros(establecimiento));
                establecimientoList = productoRepository.CargarRegistros();
                return message;
        }
        public List<Establecimiento> CargarRegistros()
        {
            return establecimientoList;
        }
        
        
        
    }
}
