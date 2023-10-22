using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace ConsoleApp1
{
    internal class Principal
    {
        static void Main(string[] args)
        {
            Console.Title = "/tMi Aplicación en Pantalla Completa";
            Console.WindowHeight = Console.LargestWindowHeight; 
            Console.WindowWidth = Console.LargestWindowWidth;   
            Console.BufferHeight = Console.LargestWindowHeight; 
            Console.BufferWidth = Console.LargestWindowWidth;
            Establecimiento producto = new Establecimiento();
            MenuPrincipal menu = new MenuPrincipal(producto);
            menu.menuPrincipal_();

        }
    }
}
