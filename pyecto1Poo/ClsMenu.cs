using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyecto1Poo
{
    internal class ClsMenu
    {
        static Clspagos pagos = new Clspagos();

        public static void Menu()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú Principal");
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Realizar Pagos");
                Console.WriteLine("3. Consultar Pagos");
                Console.WriteLine("4. Modificar Pagos");
                Console.WriteLine("5. Eliminar Pagos");
                Console.WriteLine("6. Submenú Reportes");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Clspagos.InicializarVectores();
                        break;
                    case 2:
                        Clspagos.RealizarPagos();
                        break;
                    case 3:
                        Clspagos.ConsultarPagos();
                        break;
                    case 4:
                        Clspagos.ModificarPagos();
                        break;
                    case 5:
                        Clspagos.EliminarPagos();
                        break;
                    case 6:
                        SubmenuReportes();
                        break;
                    case 7:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                        break;
                }
            } while (opcion != 7);
        }
        static void SubmenuReportes()
        {
            int opcionReporte;
            do
            {
                Console.WriteLine("Submenú Reportes");
                Console.WriteLine("1. Ver todos los Pagos");
                Console.WriteLine("2. Ver Pagos por tipo de Servicio");
                Console.WriteLine("3. Ver Pagos por código de caja");
                Console.WriteLine("4. Ver Dinero Comisionado por servicios");
                Console.WriteLine("5. Regresar Menú Principal");
                Console.Write("Seleccione una opción de reporte: ");
                opcionReporte = int.Parse(Console.ReadLine());

                switch (opcionReporte)
                {
                    case 1:
                        ClsReporte.GenerarReporte();
                        break;
                    case 2:
                        ClsReporte.ReportePorTipoDeServicio();
                        break;
                    case 3:
                        ClsReporte.ReportePorCodigoDeCaja();
                        break;
                    case 4:
                        ClsReporte.ReporteComisionesPorServicio();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                        break;
                }
            } while (opcionReporte != 5);
        }

       


    }
}
