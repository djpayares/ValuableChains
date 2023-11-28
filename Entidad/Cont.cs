using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entidad
{
    public class Cont
    {
        public Cont() { }
        public string ID { get; set; }
        public string Joya { get; set; }
        public string Quilates { get; set; }
        public double Valor { get; set; }



        public Cont(string id, string joya, string quilates, double valor)
        {
            this.ID = id;
            this.Joya = joya; 
            this.Quilates = quilates;
            this.Valor = valor;

        }

        public override string ToString()
        {
            return $"{ID};" +
                $"{Joya};" +
                $"{Quilates};" +
                $"{Valor};";
        }

    }
}
