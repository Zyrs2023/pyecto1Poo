using System;

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
                Console.Clear(); // Limpia la pantalla antes de mostrar el menú
                Console.WriteLine(new string('=', 30));
                Console.WriteLine("Menú Principal");
                Console.WriteLine(new string('=', 30));
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Realizar Pagos");
                Console.WriteLine("3. Consultar Pagos");
                Console.WriteLine("4. Modificar Pagos");
                Console.WriteLine("5. Eliminar Pagos");
                Console.WriteLine("6. Submenú Reportes");
                Console.WriteLine("7. Salir");
                Console.WriteLine(new string('-', 30));
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    opcion = 0; // Asignar un valor que mantenga el bucle en caso de entrada inválida.
                    Console.ReadKey(); // Pausa antes de limpiar la pantalla.
                }
                else
                {
                    Console.Clear(); // Limpia la pantalla antes de ejecutar la opción.
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
                    if (opcion != 7) // No limpiar la pantalla inmediatamente si el usuario elige salir.
                    {
                        Console.WriteLine("Presione una tecla para continuar...");
                        Console.ReadKey();
                    }
                }
            } while (opcion != 7);
        }

        static void SubmenuReportes()
        {
            int opcionReporte;
            do
            {
                Console.Clear(); // Limpia la pantalla antes de mostrar el submenú
                Console.WriteLine(new string('=', 30));
                Console.WriteLine("Submenú Reportes");
                Console.WriteLine(new string('=', 30));
                Console.WriteLine("1. Ver todos los Pagos");
                Console.WriteLine("2. Ver Pagos por tipo de Servicio");
                Console.WriteLine("3. Ver Pagos por código de caja");
                Console.WriteLine("4. Ver Dinero Comisionado por servicios");
                Console.WriteLine("5. Regresar Menú Principal");
                Console.WriteLine(new string('-', 30));
                Console.Write("Seleccione una opción de reporte: ");

                if (!int.TryParse(Console.ReadLine(), out opcionReporte))
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    opcionReporte = 0; // Asignar un valor que mantenga el bucle en caso de entrada inválida.
                    Console.ReadKey(); // Pausa antes de limpiar la pantalla.
                }
                else
                {
                    Console.Clear(); // Limpia la pantalla antes de ejecutar la opción.
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
                            // Automáticamente regresa al menú principal.
                            break;
                        default:
                            Console.WriteLine("Opción no válida, por favor intente de nuevo.");
                            break;
                    }
                    if (opcionReporte != 5) // No limpiar la pantalla inmediatamente si el usuario elige regresar.
                    {
                        Console.WriteLine("Presione una tecla para regresar al menú principal...");
                        Console.ReadKey();
                    }
                }
            } while (opcionReporte != 5);
        }
    }
}
