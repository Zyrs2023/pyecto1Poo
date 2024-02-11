using System;
using System.Globalization;

namespace pyecto1Poo
{
    internal class ClsReporte
    {
        // Método para generar reporte con alineación mejorada
        public static void GenerarReporte()
        {
            try
            {
                // Establecer la configuración regional para la consola
                CultureInfo cultureInfo = new CultureInfo("es-CR");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

                Console.Clear();
                Console.WriteLine("Sistema Pago de Servicios Públicos".PadLeft(40));
                Console.WriteLine("Tienda La Favorita - Reporte Todos los Pagos".PadLeft(52));
                Console.WriteLine(new string('=', 80));
                Console.WriteLine("{0, -10} {1, -20} {2, -15} {3, -10} {4, -10} {5, -10} {6, 12}", "# Pago", "Fecha/Hora Pago", "Cedula", "Nombre", "Apellido1", "Apellido2", "Monto Recibido");
                Console.WriteLine(new string('=', 80));

                decimal montoTotal = 0;
                for (int i = 0; i < Clspagos.contadorPagos; i++)
                {
                    Console.WriteLine("{0, -10} {1, -20} {2, -15} {3, -10} {4, -10} {5, -10} {6, 12:C}", Clspagos.numeroPago[i], Clspagos.fechaPago[i] + " " + Clspagos.horaPago[i], Clspagos.cedula[i], Clspagos.nombre[i], Clspagos.apellido1[i], Clspagos.apellido2[i], Clspagos.montoPagar[i]);
                    montoTotal += Clspagos.montoPagar[i];
                }

                Console.WriteLine(new string('=', 80));
                Console.WriteLine($"{"Total de Registros",-58}{Clspagos.contadorPagos,22}");
                Console.WriteLine($"{"Monto Total",-58}{montoTotal,22:C}");
                Console.WriteLine(new string('=', 80));
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el reporte: {ex.Message}");
            }
        }

        // Método para reporte por tipo de servicio
        public static void ReportePorTipoDeServicio()
        {
            try
            {
                // Establecer la configuración regional para la consola
                CultureInfo cultureInfo = new CultureInfo("es-CR");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Sistema Pago de Servicios Públicos".PadLeft(40));
                    Console.WriteLine("Tienda La Favorita - Reporte Pagos por Tipo de Servicio".PadLeft(59));
                    Console.WriteLine(new string('=', 80));
                    Console.WriteLine("Seleccione Código de Servicio".PadLeft(50));
                    Console.WriteLine("[1] Electricidad\t[2] Teléfono\t[3] Agua".PadLeft(57));
                    Console.WriteLine(new string('=', 80));

                    Console.Write("Ingrese el tipo de servicio: ");
                    int tipoServicio;
                    if (!int.TryParse(Console.ReadLine(), out tipoServicio) || tipoServicio < 1 || tipoServicio > 3)
                    {
                        Console.WriteLine("Tipo de servicio inválido.");
                        return;
                    }

                    Console.WriteLine("\n# Pago\tFecha/Hora Pago\tCedula\tNombre\tApellido1\tApellido2\tMonto Recibido");
                    Console.WriteLine("================================================================================");

                    decimal montoTotal = 0;
                    int totalRegistros = 0;
                    for (int i = 0; i < Clspagos.contadorPagos; i++)
                    {
                        if (Clspagos.tipoServicio[i] == tipoServicio)
                        {
                            Console.WriteLine(String.Format("{0, -10} {1, -20} {2, -15} {3, -10} {4, -10} {5, -10} {6, 12:C}", Clspagos.numeroPago[i], Clspagos.fechaPago[i] + " " + Clspagos.horaPago[i], Clspagos.cedula[i], Clspagos.nombre[i], Clspagos.apellido1[i], Clspagos.apellido2[i], Clspagos.montoPagar[i]));
                            montoTotal += Clspagos.montoPagar[i];
                            totalRegistros++;
                        }
                    }

                    Console.WriteLine(new string('=', 80));
                    Console.WriteLine($"Total de Registros\t{totalRegistros}");
                    Console.WriteLine($"Monto Total\t{montoTotal:C}");
                    Console.WriteLine(new string('=', 80));

                    // Preguntar al usuario si desea consultar otro tipo de servicio
                    Console.Write("¿Desea consultar otro tipo de servicio? (S/N): ");
                    string respuesta = Console.ReadLine().ToUpper();
                    if (respuesta != "S")
                    {
                        break; // Salir del bucle si la respuesta no es 'S'
                    }
                } while (true); // Repetir el proceso mientras la condición sea verdadera

                Console.WriteLine("Presione cualquier Tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el reporte por tipo de servicio: {ex.Message}");
            }
        }

        // Método para reporte por código de caja
        public static void ReportePorCodigoDeCaja()
        {
            try
            {
                // Establecer la configuración regional para la consola
                CultureInfo cultureInfo = new CultureInfo("es-CR");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

                do
                {
                    Console.Clear();
                    Console.WriteLine("Sistema Pago de Servicios Públicos".PadLeft(40));
                    Console.WriteLine("Tienda La Favorita - Reporte Pagos por Código de Caja".PadLeft(56));
                    Console.WriteLine(new string('=', 80));
                    Console.WriteLine("Seleccione Código de Cajero".PadLeft(50));
                    Console.WriteLine("[1] Caja #1\t[2] Caja #2\t[3] Caja #3".PadLeft(51));
                    Console.WriteLine(new string('=', 80));

                    Console.Write("Ingrese el código de caja: ");
                    int codigoCaja;
                    if (!int.TryParse(Console.ReadLine(), out codigoCaja) || codigoCaja < 1 || codigoCaja > 3)
                    {
                        Console.WriteLine("Código de caja inválido.");
                        return;
                    }

                    Console.WriteLine("\n# Pago\tFecha/Hora Pago\tCedula\tNombre\tApellido1\tApellido2\tMonto Recibido");
                    Console.WriteLine("================================================================================");

                    decimal montoTotal = 0;
                    int totalRegistros = 0;
                    for (int i = 0; i < Clspagos.contadorPagos; i++)
                    {
                        if (Clspagos.numeroCaja[i] == codigoCaja)
                        {
                            Console.WriteLine(String.Format("{0, -10} {1, -20} {2, -15} {3, -10} {4, -10} {5, -10} {6, 12:C}", Clspagos.numeroPago[i], Clspagos.fechaPago[i] + " " + Clspagos.horaPago[i], Clspagos.cedula[i], Clspagos.nombre[i], Clspagos.apellido1[i], Clspagos.apellido2[i], Clspagos.montoPagar[i]));
                            montoTotal += Clspagos.montoPagar[i];
                            totalRegistros++;
                        }
                    }

                    Console.WriteLine(new string('=', 80));
                    Console.WriteLine($"Total de Registros\t{totalRegistros}");
                    Console.WriteLine($"Monto Total\t{montoTotal:C}");
                    Console.WriteLine(new string('=', 80));

                    // Preguntar al usuario si desea consultar otro código de caja
                    Console.Write("¿Desea consultar otro código de caja? (S/N): ");
                    string respuesta = Console.ReadLine().ToUpper();
                    if (respuesta != "S")
                    {
                        break; // Salir del bucle si la respuesta no es 'S'
                    }
                } while (true); // Repetir el proceso mientras la condición sea verdadera

                Console.WriteLine("Presione cualquier Tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el reporte por código de caja: {ex.Message}");
            }
        }

        // Método para reporte de comisiones por servicio
        public static void ReporteComisionesPorServicio()
        {
            try
            {
                // Establecer la configuración regional para la consola
                CultureInfo cultureInfo = new CultureInfo("es-CR");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

                Console.Clear();
                Console.WriteLine("Sistema Pago de Servicios Públicos".PadLeft(40));
                Console.WriteLine("Reporte Dinero Comisionado - Desglose por Tipo de Servicio".PadLeft(63));
                Console.WriteLine(new string('=', 80));
                Console.WriteLine("ITEM\tCant. Transacciones\tTotal Comisionado");
                Console.WriteLine(new string('=', 80));

                int[] transaccionesPorServicio = new int[4];
                decimal[] comisionesPorServicio = new decimal[4];

                for (int i = 0; i < Clspagos.contadorPagos; i++)
                {
                    int servicio = Clspagos.tipoServicio[i];
                    if (servicio >= 1 && servicio <= 3)
                    {
                        transaccionesPorServicio[servicio]++;
                        comisionesPorServicio[servicio] += Clspagos.montoComision[i];
                    }
                }

                decimal totalComisionado = 0;
                int totalTransacciones = 0;
                string[] nombresServicios = { "", "Electricidad", "Teléfono", "Agua" };

                for (int i = 1; i < transaccionesPorServicio.Length; i++)
                {
                    Console.WriteLine($"{i}-{nombresServicios[i],-12}{transaccionesPorServicio[i],18}\t\t{comisionesPorServicio[i],20:C}".Replace("$", "₡"));
                    totalComisionado += comisionesPorServicio[i];
                    totalTransacciones += transaccionesPorServicio[i];
                }

                Console.WriteLine(new string('=', 80));
                Console.WriteLine($"Total\t{totalTransacciones,-22}{totalComisionado,22:C}".Replace("$", "₡"));
                Console.WriteLine(new string('=', 80));
                Console.WriteLine("Pulse cualquier tecla para regresar al submenú de reportes");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el reporte de comisiones por servicio: {ex.Message}");
            }
        }
    }
}
