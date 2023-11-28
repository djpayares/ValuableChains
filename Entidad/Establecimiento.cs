using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Establecimiento
    {
        public string Idproducto { get; set; }
        public int Diamante { get; set; }
        public int Rubi { get; set; }
        public int Zafiro { get; set; }
        public int Esmeralda { get; set; }


        public Establecimiento() { }

        public Establecimiento(string idproducto,int diamante, int rubi, int zafiro, int esmeralda)
        {
            this.Idproducto = idproducto;
           this.Diamante = diamante;
           this.Rubi = rubi;
           this.Zafiro = zafiro;
           this.Esmeralda = esmeralda;
            
        }
        
        
        public override string ToString()
        {
            return $"{Idproducto};" +
                $"{Diamante};" +
                $"{Rubi};" +
                $"{Zafiro};" +
                $"{Esmeralda};";
        }
    }
}
