using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Logica;

namespace ConsoleApp1
{
    class MenuPrincipal
    {
        private Establecimiento produto;
        private EstablecimientoService productoService = new EstablecimientoService();
        public MenuPrincipal(Establecimiento produto)
        {
            this.produto = produto;
        }

        public int menuPrincipal()
        {
            int OPC;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(101, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(102, 7); Console.WriteLine("PARCIAL DE PROGRAMACION III");
            Console.SetCursorPosition(94, 8); Console.WriteLine("SOFTWARE DE LA ALCALDIA DE LAS FLORES DEL CAMPO");
            Console.SetCursorPosition(102, 9); Console.WriteLine("M E N U  P R I N C I P A L");
            Console.SetCursorPosition(101, 13); Console.WriteLine("1. REGISTRO DE ESTABLECIMIENTO");
            Console.SetCursorPosition(101, 14); Console.WriteLine("2. CONSULTA DE ESTABLECIMIENTO");
            Console.SetCursorPosition(101, 16); Console.WriteLine("3. ELIMINAR ESTABLECIMIENTO");
            Console.SetCursorPosition(101, 18); Console.WriteLine("4. SALIR");
            do
            {
                Console.SetCursorPosition(101, 21); Console.WriteLine("Seleccione una opcion: ");
                Console.SetCursorPosition(124, 21); OPC = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(124, 21); Console.WriteLine("         ");
                Console.SetCursorPosition(124, 26); Console.WriteLine("Opcion no valida");
            } while ((OPC < 1) || (OPC > 4));
            Console.SetCursorPosition(124, 21); Console.WriteLine("                                     ");
            Console.SetCursorPosition(124, 26); Console.WriteLine("                                     ");
            return OPC;
        }
        public void menuPrincipal_()
        {

            int MENU_;
            char OP = 'S';
            while (OP == 'S')
            {
                MENU_ = menuPrincipal();
                switch (MENU_)
                {
                    case 1:
                        Console.Clear();
                        registro();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        MostrarRegistro();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        EliminarRegistro();
                        Console.Clear();
                        break;
                    case 4:
                        OP = 'N';
                        break;
                }
            }
        }
        public void registro()
        {
            string idEstablecimiento;
            string nombreEstablecimiento;
            double ingresosAnuales;
            double gastosAnuales;
            int tiempoFuncionamiento;
            string tipoResponsabilidad;

            char OP = 'S';
            while (OP == 'S')
            {
                try
                {
                    titulos1();
                    Console.SetCursorPosition(35, 11); Console.WriteLine("ID ESTABLECIMIENTO       : ");
                    Console.SetCursorPosition(35, 12); Console.WriteLine("NOMBRE ESTABLECIMIENTO   : ");
                    Console.SetCursorPosition(35, 13); Console.WriteLine("INGRESOS ANUALES         : ");
                    Console.SetCursorPosition(35, 14); Console.WriteLine("GASTOS ANUALES           : ");
                    Console.SetCursorPosition(35, 15); Console.WriteLine("TIEMPO DE FUNCIONAMIENTO : ");
                    Console.SetCursorPosition(35, 16); Console.WriteLine("TIPO DE RESPONSABILIDAD  : ");

                    Console.SetCursorPosition(62, 11); idEstablecimiento = Console.ReadLine();
                    Console.SetCursorPosition(62, 12); nombreEstablecimiento = Console.ReadLine().ToUpper();
                    do
                    {
                        Console.SetCursorPosition(62, 13); ingresosAnuales = Convert.ToDouble(Console.ReadLine());
                    } while (ingresosAnuales < 0);
                    do
                    {
                        Console.SetCursorPosition(62, 14); gastosAnuales = Convert.ToDouble(Console.ReadLine());
                    } while (gastosAnuales < 0);
                    do
                    {
                        Console.SetCursorPosition(62, 15); tiempoFuncionamiento = Convert.ToInt32(Console.ReadLine());
                    } while (tiempoFuncionamiento < 0);
                    do
                    {
                        Console.SetCursorPosition(35, 25); Console.WriteLine("Digite S: Responsable de IVA N: No responsable de IVA");
                        Console.SetCursorPosition(62, 16); tipoResponsabilidad = Console.ReadLine().ToUpper();
                    } while ((tipoResponsabilidad != "S") && (tipoResponsabilidad != "N"));
                    Establecimiento producto = new Establecimiento(idEstablecimiento, nombreEstablecimiento, ingresosAnuales, gastosAnuales, tiempoFuncionamiento,
                        tipoResponsabilidad, 0, 0, 0, 0);
                    producto.Ganancias();
                    producto.CalcularValorUVT();
                    producto.Tarifa();
                    producto.Impuesto();
                    Console.SetCursorPosition(34, 25); Console.WriteLine(productoService.GuardarRegistros(producto));
                    {
                        Console.SetCursorPosition(34, 18); Console.WriteLine("¿Desea continuar? S/N : ");
                        Console.SetCursorPosition(58, 18); OP = Convert.ToChar(Console.ReadLine());
                        OP = char.ToUpper(OP);
                        Console.Clear();
                    } while ((OP != 'S') && (OP != 'N')) ;
                }
                catch (IOException)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Ingresa un dato valido");
                }
            }
        }
        public void MostrarRegistro()
        {
            titulos4();
            try
            {
                Console.SetCursorPosition(35, 15); Console.WriteLine("ID ESTABLECIMIENTO  ESTABLECIMIENTO            INGRESOS ANUALES     GASTOS ANUALES    TIEMPO DE FUNCIONAMIENTO  TIPO DE RESPONSABILIDAD  GANANCIA     VALOR UVT   TARIFA  IMPUESTO");
                int X = 17;
                var lista = productoService.CargarRegistros();
                foreach (var i in lista)
                {
                    Console.SetCursorPosition(42, X); Console.WriteLine(i.IdEstablecimiento);
                    Console.SetCursorPosition(59, X); Console.WriteLine(i.NombreEstablecimiento);
                    Console.SetCursorPosition(83, X); Console.WriteLine($"{i.IngresosAnuales:C}");
                    Console.SetCursorPosition(103, X); Console.WriteLine($"{i.GastosAnuales:C}");
                    Console.SetCursorPosition(131, X); Console.WriteLine(i.TiempoFuncionamiento);
                    Console.SetCursorPosition(159, X); Console.WriteLine(i.TipoResponsabilidad);
                    Console.SetCursorPosition(169, X); Console.WriteLine($"{i.Ganancia:C}");
                    Console.SetCursorPosition(187, X); Console.WriteLine(i.ValorUVT.ToString("F1"));
                    Console.SetCursorPosition(199, X); Console.WriteLine(i.TarifaAplicada.ToString("F1"));
                    Console.SetCursorPosition(206, X); Console.WriteLine($"{i.ImpuestoApagar:C}");
                    X++;
                }
                Console.SetCursorPosition(115, 14 + X); Console.WriteLine("Presione cualquier tecla para continuar.");
                Console.SetCursorPosition(155, 14 + X); Console.ReadKey();
                Console.Clear();
            }
            catch (IOException)
            {
                Console.SetCursorPosition(108, 20); Console.Write("Ups... Algo pasó");
                Console.SetCursorPosition(108, 25); Console.WriteLine("No hay registros para mostrar.");
            }
        }
        private void EliminarRegistro()
        {
            Console.Clear();
            titulos2();
            Console.SetCursorPosition(35, 11); Console.Write("Ingrese el ID del establecimiento que desea eliminar: ");
            Console.SetCursorPosition(89, 11); string idAEliminar = Console.ReadLine();

            string mensaje = productoService.EliminarRegistro(idAEliminar);

            Console.SetCursorPosition(35, 13); Console.WriteLine(mensaje);
            Console.SetCursorPosition(30, 15); Console.WriteLine("Presione Enter para continuar.");
            Console.SetCursorPosition(50, 15); Console.ReadLine();
        }
        public void titulos1()
        {
            Console.SetCursorPosition(115, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(116, 7); Console.WriteLine("PARCIAL DE PROGRAMACION III");
            Console.SetCursorPosition(108, 8); Console.WriteLine("SOFTWARE DE LA ALCALDIA DE LAS FLORES DEL CAMPO");
            Console.SetCursorPosition(122, 9); Console.WriteLine("R E G I S T R O");
        }
        public void titulos2()
        {
            Console.SetCursorPosition(115, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(116, 7); Console.WriteLine("PARCIAL DE PROGRAMACION III");
            Console.SetCursorPosition(108, 8); Console.WriteLine("SOFTWARE DE LA ALCALDIA DE LAS FLORES DEL CAMPO");
            Console.SetCursorPosition(119, 9); Console.WriteLine("E L I M I N A C I O N");
        }
        public void titulos4()
        {
            Console.SetCursorPosition(115, 6); Console.WriteLine("UNIVERSIDAD POPULAR DEL CESAR");
            Console.SetCursorPosition(118, 7); Console.WriteLine("PARCIAL DE PROGRAMACION III");
            Console.SetCursorPosition(108, 8); Console.WriteLine("SOFTWARE DE LA ALCALDIA DE LAS FLORES DEL CAMPO");
            Console.SetCursorPosition(114, 9); Console.WriteLine("INFORMACION DE ESTABLECIMIENTO");
        }
    }
}
