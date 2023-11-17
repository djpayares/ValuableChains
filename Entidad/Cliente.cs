using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Cliente
    {
        

        public string Id {get;set;}

        public string Name { get;set;}
        public string Telefono { get;set;}
        public string Direccion { get; set; }
        public double Total { get;set;}
        
        


        public Cliente()
        {
        }

        public Cliente(string id, string name,string telefono,string direccion, double total)
        {
            this.Id = id;
            this.Name = name;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Total = total;
        }
        public override string ToString()
        {
            return $"{Id};" +
                $"{Name};" +
                $"{Telefono};" +
                $"{Direccion};" +
                $"{Total};";
        }

    }
}
