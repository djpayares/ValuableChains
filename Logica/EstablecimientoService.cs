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
        
        public List<Establecimiento> ConsultarTodos()
        {
            return establecimientoList;
        }
        
    }
}
