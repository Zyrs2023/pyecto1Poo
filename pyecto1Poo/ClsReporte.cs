using System;

namespace pyecto1Poo
{
    internal class ClsReporte
    {
        public static void GenerarReporte()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Sistema Pago de Servicios Públicos");
                Console.WriteLine("Tienda La Favorita - Reporte Todos los Pagos");
                Console.WriteLine("====================================================================");
                Console.WriteLine("# Pago\tFecha/Hora Pago\tCedula\tNombre\tApellido1\tApellido2\tMonto Recibido");
                Console.WriteLine("====================================================================");

                decimal montoTotal = 0;
                for (int i = 0; i < Clspagos.contadorPagos; i++)
                {
                    Console.WriteLine($"{Clspagos.numeroPago[i]}\t{Clspagos.fechaPago[i]} {Clspagos.horaPago[i]}\t{Clspagos.cedula[i]}\t{Clspagos.nombre[i]}\t{Clspagos.apellido1[i]}\t{Clspagos.apellido2[i]}\t{Clspagos.montoPagar[i]}");
                    montoTotal += Clspagos.montoPagar[i];
                }

                Console.WriteLine("====================================================================");
                Console.WriteLine($"Total de Registros\t{Clspagos.contadorPagos}");
                Console.WriteLine($"Monto Total\t{montoTotal}");
                Console.WriteLine("====================================================================");
                Console.WriteLine("Presione cualquier tecla para ver Registro");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error al generar el reporte: {ex.Message}");
            }
        }

        public static void ReportePorTipoDeServicio()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Sistema Pago de Servicios Públicos");
                Console.WriteLine("Tienda La Favorita - Reporte Todos los Pagos por Tipo de Servicio");
                Console.WriteLine("Seleccione codigo de Servicio\t[1] Electricidad\t[2] Telefono\t[3] Agua");
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
                        Console.WriteLine($"{Clspagos.numeroPago[i]}\t{Clspagos.fechaPago[i]} {Clspagos.horaPago[i]}\t{Clspagos.cedula[i]}\t{Clspagos.nombre[i]}\t{Clspagos.apellido1[i]}\t{Clspagos.apellido2[i]}\t{Clspagos.montoPagar[i]}");
                        montoTotal += Clspagos.montoPagar[i];
                        totalRegistros++;
                    }
                }

                Console.WriteLine("================================================================================");
                Console.WriteLine($"Total de Registros\t{totalRegistros}");
                Console.WriteLine($"Monto Total\t{montoTotal}");
                Console.WriteLine("================================================================================");
                Console.WriteLine("Presione cualquier Tecla para ver Registro");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error al generar el reporte por tipo de servicio: {ex.Message}");
            }
        }

        public static void ReportePorCodigoDeCaja()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Sistema Pago de Servicios Públicos");
                Console.WriteLine("Tienda La Favorita - Reporte Todos los Pagos por Código De Cajero");
                Console.WriteLine("Seleccione código de Cajero: [1] Caja #1  [2] Caja #2  [3] Caja #3");
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
                        Console.WriteLine($"{Clspagos.numeroPago[i]}\t{Clspagos.fechaPago[i]} {Clspagos.horaPago[i]}\t{Clspagos.cedula[i]}\t{Clspagos.nombre[i]}\t{Clspagos.apellido1[i]}\t{Clspagos.apellido2[i]}\t{Clspagos.montoPagar[i]}");
                        montoTotal += Clspagos.montoPagar[i];
                        totalRegistros++;
                    }
                }

                Console.WriteLine("================================================================================");
                Console.WriteLine($"Total de Registros\t{totalRegistros}");
                Console.WriteLine($"Monto Total\t{montoTotal}");
                Console.WriteLine("================================================================================");
                Console.WriteLine("Presione cualquier Tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error al generar el reporte por código de caja: {ex.Message}");
            }
        }

        public static void ReporteComisionesPorServicio()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Reporte Dinero Comisionado - Desglose por Tipo de Servicio");
                Console.WriteLine("================================================================");
                Console.WriteLine("ITEM\tCant. Transacciones\tTotal Comisionado");
                Console.WriteLine("================================================================");

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
                    Console.WriteLine($"{i}-{nombresServicios[i]}\t{transaccionesPorServicio[i]}\t\t{comisionesPorServicio[i]}");
                    totalComisionado += comisionesPorServicio[i];
                    totalTransacciones += transaccionesPorServicio[i];
                }

                Console.WriteLine("================================================================");
                Console.WriteLine($"Total\t{totalTransacciones}\t\t{totalComisionado}");
                Console.WriteLine("================================================================");
                Console.WriteLine("Pulse cualquier tecla para regresar al submenú de reportes");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ha ocurrido un error al generar el reporte de comisiones por servicio: {ex.Message}");
            }
        }
    }
}
