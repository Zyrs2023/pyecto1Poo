using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pyecto1Poo
{
    internal class Clspagos
    {
        const int MaxPagos = 10;
        public static int[] numeroPago = new int[MaxPagos];
        public static string[] fechaPago = new string[MaxPagos];
        public static string[] horaPago = new string[MaxPagos];
        public static string[] cedula = new string[MaxPagos];
        public static string[] nombre = new string[MaxPagos];
        public static string[] apellido1 = new string[MaxPagos];
        public static string[] apellido2 = new string[MaxPagos];
        public static int[] numeroCaja = new int[MaxPagos];
        public static int[] tipoServicio = new int[MaxPagos];
        public static string[] numeroFactura = new string[MaxPagos];
        public static decimal[] montoPagar = new decimal[MaxPagos];
        public static decimal[] montoComision = new decimal[MaxPagos];
        public static decimal[] montoDeducido = new decimal[MaxPagos];
        public static decimal[] montoPagaCliente = new decimal[MaxPagos];
        public static decimal[] vuelto = new decimal[MaxPagos];
        
        public static int contadorPagos = 0;

        public static void InicializarVectores()
        {
           
            for (int i = 0; i < MaxPagos; i++)
            {
                numeroPago[i] = 0; 
                fechaPago[i] = string.Empty;
                horaPago[i] = string.Empty;
                cedula[i] = string.Empty;
                nombre[i] = string.Empty;
                apellido1[i] = string.Empty;
                apellido2[i] = string.Empty;
                numeroCaja[i] = 0; 
                tipoServicio[i] = 0; 
                numeroFactura[i] = string.Empty;
                montoPagar[i] = 0M;
                montoComision[i] = 0M;
                montoDeducido[i] = 0M;
                montoPagaCliente[i] = 0M;
                vuelto[i] = 0M;
            }
            contadorPagos = 0;
            Console.WriteLine("Vectores inicializados.");
        }


        public static void RealizarPagos()
        {
            try
            {
                if (contadorPagos >= MaxPagos)
                {
                    Console.WriteLine("Vectores Llenos");
                    return;
                }

                Console.WriteLine("Ingrese la Cedula:");
                cedula[contadorPagos] = Console.ReadLine();
                Console.WriteLine("Ingrese el Nombre:");
                nombre[contadorPagos] = Console.ReadLine();
                Console.WriteLine("Ingrese el primer apellido:");
                apellido1[contadorPagos] = Console.ReadLine();
                Console.WriteLine("Ingrese el segundo apellido:");
                apellido2[contadorPagos] = Console.ReadLine();

                Console.WriteLine("Ingrese el Tipo de Servicio (1= Luz, 2= Teléfono, 3= Agua):");
                tipoServicio[contadorPagos] = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese el Numero de Factura:");
                numeroFactura[contadorPagos] = Console.ReadLine();

                Console.WriteLine("Ingrese el Monto a Pagar:");
                montoPagar[contadorPagos] = decimal.Parse(Console.ReadLine());


                switch (tipoServicio[contadorPagos])
                {
                    case 1:
                        montoComision[contadorPagos] = montoPagar[contadorPagos] * 0.04M;
                        break;
                    case 2:
                        montoComision[contadorPagos] = montoPagar[contadorPagos] * 0.055M;
                        break;
                    case 3:
                        montoComision[contadorPagos] = montoPagar[contadorPagos] * 0.065M;
                        break;
                }
                montoDeducido[contadorPagos] = montoPagar[contadorPagos] - montoComision[contadorPagos];

                Console.WriteLine("Ingrese el Monto que Paga el Cliente:");
                montoPagaCliente[contadorPagos] = decimal.Parse(Console.ReadLine());
                vuelto[contadorPagos] = montoPagaCliente[contadorPagos] - montoPagar[contadorPagos];


                if (montoPagaCliente[contadorPagos] < montoPagar[contadorPagos])
                {
                    Console.WriteLine("El monto pagado no puede ser menor al monto a pagar.");
                    return;
                }

                numeroPago[contadorPagos] = contadorPagos + 1;
                fechaPago[contadorPagos] = DateTime.Now.ToString("dd/MM/yyyy");
                horaPago[contadorPagos] = DateTime.Now.ToString("hh:mm tt");

                numeroCaja[contadorPagos] = new Random().Next(1, 4);

                contadorPagos++;

                MostrarPago(contadorPagos - 1);

                Console.WriteLine("Pago realizado exitosamente.");
                Console.Write("Desea Continuar S/N? ");
                var continuar = Console.ReadLine();
                if (continuar?.ToUpper() != "S")
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar el pago: {ex.Message}");
            }
        }
        static void MostrarPago(int indice)
        {
            try
            {

                Console.Clear();
                Console.WriteLine("Sistema Pago de Servicios Públicos");
                Console.WriteLine("Tienda La Favorita - Ingreso de Datos");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine($"Numero de Pago: {numeroPago[indice]}");
                Console.WriteLine($"Fecha: {fechaPago[indice]} \t\tHora: {horaPago[indice]}");
                Console.WriteLine($"Cedula: {cedula[indice]} \tNombre: {nombre[indice]}");
                Console.WriteLine($"Apellido1: {apellido1[indice]} \tApellido 2: {apellido2[indice]}");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine($"Tipo de Servicio: {tipoServicio[indice]} \t[1- Electricidad  2-Telefono  3-Agua]");
                Console.WriteLine($"Numero de Factura: {numeroFactura[indice]}");
                Console.WriteLine($"Comision autorizada: {montoComision[indice]}");
                Console.WriteLine($"Monto deducido: {montoDeducido[indice]}");
                Console.WriteLine($"Monto Pagar: {montoPagar[indice]}");
                Console.WriteLine($"Paga con: {montoPagaCliente[indice]}");
                Console.WriteLine($"Vuelto: {vuelto[indice]}");
                // Línea añadida para mostrar el número de caja.
                Console.WriteLine($"Numero de Caja: {numeroCaja[indice]}");
                Console.WriteLine("----------------------------------------------------");
                Console.Write("Desea Continuar S/N? ");
            } catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar el pago: {ex.Message}");
            }
        }

        public static void ConsultarPagos()
        {
            try
            {
                Console.Write("Ingrese el número de pago a consultar: ");
                int numPago;
                if (int.TryParse(Console.ReadLine(), out numPago))
                {
                    int index = Array.IndexOf(numeroPago, numPago);
                    Console.Clear();
                    Console.WriteLine("Sistema Pago de Servicios Públicos");
                    Console.WriteLine("Tienda La Favorita - Consulta de Datos");
                    Console.WriteLine();
                    Console.WriteLine($"Numero de Pago: {numPago}");

                    if (index != -1)
                    {
                        Console.WriteLine($"Dato Encontrado Posicion Vector {index}");
                    }
                    else
                    {
                        Console.WriteLine("Pago no se encuentra Registrado");
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presione cualquier Tecla para ver Registro");
                    Console.ReadKey();


                    if (index != -1)
                    {
                        Console.Clear();
                        Console.WriteLine("Sistema Pago de Servicios Públicos");
                        Console.WriteLine("Tienda La Favorita - Consulta de Datos");
                        Console.WriteLine($"Numero de Pago: {numeroPago[index]}");
                        Console.WriteLine($"Fecha: {fechaPago[index]} \tHora: {horaPago[index]}");
                        Console.WriteLine($"Cedula: {cedula[index]} \tNombre: {nombre[index]} {apellido1[index]} {apellido2[index]}");
                        Console.WriteLine($"Tipo de Servicio: {tipoServicio[index]} \t[1- Electricidad 2-Telefono 3-Agua]");
                        Console.WriteLine($"Numero de Factura: {numeroFactura[index]}");
                        Console.WriteLine($"Comision autorizada: {montoComision[index]}");
                        Console.WriteLine($"Monto deducido: {montoDeducido[index]}");
                        Console.WriteLine($"Monto Pagar: {montoPagar[index]}");
                        Console.WriteLine($"Paga con: {montoPagaCliente[index]}");
                        Console.WriteLine($"Vuelto: {vuelto[index]}");
                        Console.WriteLine($"Numero de Caja: {numeroCaja[index]}");
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("\nPresione cualquier tecla para ver Registro");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Pago no se encuentra Registrado");
                        Console.WriteLine("Presione cualquier tecla para volver al menú principal");
                        Console.ReadKey();
                    }
                }
            }
           catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar el pago: {ex.Message}");
            }


        }
        public static void ModificarPagos()
        {
            try
            {

                Console.Write("Ingrese el número de pago a modificar: ");
                int numPago;
                if (!int.TryParse(Console.ReadLine(), out numPago))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número de pago válido.");
                    return;
                }

                int index = Array.IndexOf(numeroPago, numPago);
                if (index == -1)
                {
                    Console.WriteLine("Pago no se encuentra Registrado");
                    return;
                }

                MostrarDatosPago(index);

                bool seguirModificando = true;
                while (seguirModificando)
                {
                    Console.WriteLine("\nSeleccione el dato que desea modificar: ");
                    Console.WriteLine("A - Fecha");
                    Console.WriteLine("B - Hora");
                    Console.WriteLine("C - Cedula");
                    Console.WriteLine("D - Nombre");
                    Console.WriteLine("E - Apellido1");
                    Console.WriteLine("F - Apellido2");
                    Console.WriteLine("G - Tipo de Servicio [1- Electricidad 2-Telefono 3-Agua]");
                    Console.WriteLine("H - Numero de Factura");
                    Console.WriteLine("I - Monto a Pagar");
                    Console.WriteLine("J - Monto que Paga Cliente");
                    Console.WriteLine("K - Número de Caja");


                    Console.Write("Opción: ");
                    string opcion = Console.ReadLine().ToUpper();
                    if (string.IsNullOrEmpty(opcion) || opcion.Length > 1)
                    {
                        Console.WriteLine("Opción inválida. Por favor, ingrese una sola letra correspondiente al campo a modificar.");
                        continue;
                    }

                    Console.Write("Ingrese el nuevo dato: ");
                    string nuevoDato = Console.ReadLine();

                    bool datoValido = true;

                    switch (opcion)
                    {
                        case "A":
                            // Validar formato de fecha
                            if (!DateTime.TryParseExact(nuevoDato, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fecha))
                            {
                                datoValido = false;
                                Console.WriteLine("Formato de fecha inválido. Utilice el formato dd/MM/yyyy.");
                            }
                            else
                            {
                                fechaPago[index] = nuevoDato;
                            }
                            break;
                        case "B":
                            // Validar formato de hora
                            if (!DateTime.TryParseExact(nuevoDato, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime hora))
                            {
                                datoValido = false;
                                Console.WriteLine("Formato de hora inválido. Utilice el formato HH:mm.");
                            }
                            else
                            {
                                horaPago[index] = nuevoDato;
                            }
                            break;
                        case "C":

                            cedula[index] = nuevoDato;
                            break;
                        case "D":
                            nombre[index] = nuevoDato;
                            break;
                        case "E":
                            apellido1[index] = nuevoDato;
                            break;
                        case "F":
                            apellido2[index] = nuevoDato;
                            break;
                        case "G":
                            // Validar tipo de servicio como entero y rango
                            if (!int.TryParse(nuevoDato, out int tipoServicio) || tipoServicio < 1 || tipoServicio > 3)
                            {
                                datoValido = false;
                                Console.WriteLine("Número de tipo de servicio inválido. Debe ser entre 1 y 3.");
                            }
                            else
                            {
                                Clspagos.tipoServicio[index] = tipoServicio;
                            }
                            break;
                        case "H":
                            numeroFactura[index] = nuevoDato;
                            break;
                        case "I":
                            decimal monto;
                            datoValido = decimal.TryParse(nuevoDato, out monto) && monto >= 0;
                            if (datoValido) montoPagar[index] = monto;
                            else Console.WriteLine("Monto a pagar inválido.");
                            break;
                        case "J":
                            decimal montoCliente;
                            datoValido = decimal.TryParse(nuevoDato, out montoCliente) && montoCliente >= montoPagar[index];
                            if (datoValido) montoPagaCliente[index] = montoCliente;
                            else Console.WriteLine("Monto que paga el cliente inválido.");
                            break;
                        case "K": // Nuevo caso para número de caja
                            int numeroCaja;
                            datoValido = int.TryParse(nuevoDato, out numeroCaja) && numeroCaja >= 1 && numeroCaja <= 3;
                            if (datoValido) Clspagos.numeroCaja[index] = numeroCaja;
                            else Console.WriteLine("Número de caja inválido.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            datoValido = false;
                            break;
                    }

                    if (datoValido)
                    {
                        // Recalcular montos si es necesario y mostrar mensaje de éxito...
                        Console.WriteLine("Pago modificado con éxito.");
                        MostrarDatosPago(index); // Asegúrate de que este método muestre el número de caja modificado correctamente.
                    }

                    Console.Write("¿Desea realizar otra modificación? (S/N): ");
                    seguirModificando = Console.ReadLine().ToUpper() == "S";
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar pagos: {ex.Message}");
            }
        }

        private static void MostrarDatosPago(int index)
        {
            Console.Clear();
            Console.WriteLine("Sistema Pago de Servicios Públicos");
            Console.WriteLine("Tienda La Favorita - Consulta de Datos");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Numero de Pago: {numeroPago[index]}");
            Console.WriteLine($"Fecha: {fechaPago[index]} \tHora: {horaPago[index]}");
            Console.WriteLine($"Cedula: {cedula[index]} \tNombre: {nombre[index]} {apellido1[index]} {apellido2[index]}");
            Console.WriteLine($"Tipo de Servicio: {tipoServicio[index]} \t[1- Electricidad 2-Telefono 3-Agua]");
            Console.WriteLine($"Numero de Factura: {numeroFactura[index]}");
            Console.WriteLine($"Comision autorizada: {montoComision[index]}");
            Console.WriteLine($"Monto deducido: {montoDeducido[index]}");
            Console.WriteLine($"Monto Pagar: {montoPagar[index]}");
            Console.WriteLine($"Paga con: {montoPagaCliente[index]}");
            Console.WriteLine($"Vuelto: {vuelto[index]}");
            Console.WriteLine($"Numero de Caja: {numeroCaja[index]}");
           
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void RecalcularMontos(int index)
        {
            
            switch (tipoServicio[index])
            {
                case 1: 
                    montoComision[index] = montoPagar[index] * 0.04M; 
                    break;
                case 2: 
                    montoComision[index] = montoPagar[index] * 0.055M; 
                    break;
                case 3: 
                    montoComision[index] = montoPagar[index] * 0.065M;
                    break;
                default:
                    montoComision[index] = 0M; 
                    break;
            }
            montoDeducido[index] = montoPagar[index] - montoComision[index];

            
            vuelto[index] = montoPagaCliente[index] - montoPagar[index];
        }

        public static void EliminarPagos()
        {
            try
            {
                Console.Write("Ingrese el número de pago que desea eliminar o modificar: ");
                if (!int.TryParse(Console.ReadLine(), out int numPago))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número de pago válido.");
                    return;
                }

                int index = Array.IndexOf(numeroPago, numPago);
                if (index == -1)
                {
                    Console.WriteLine("Pago no se encuentra registrado.");
                    return;
                }

                MostrarDatosPago(index);

                Console.WriteLine("¿Desea eliminar un dato específico (D) o el registro completo (R)? [D/R]: ");
                string eleccion = Console.ReadLine().ToUpper();

                if (eleccion == "D")
                {
                    Console.WriteLine("Seleccione el dato que desea eliminar:");
                    Console.WriteLine("A - Fecha");
                    Console.WriteLine("B - Hora");
                    Console.WriteLine("C - Cédula");
                    Console.WriteLine("D - Nombre");
                    Console.WriteLine("E - Primer Apellido");
                    Console.WriteLine("F - Segundo Apellido");
                    Console.WriteLine("G - Tipo de Servicio");
                    Console.WriteLine("H - Número de Factura");
                    Console.WriteLine("I - Monto a Pagar");
                    Console.WriteLine("J - Monto que Paga Cliente");
                    Console.WriteLine("K - Número de Caja");
                    Console.Write("Opción: ");
                    string opcion = Console.ReadLine().ToUpper();

                    if (!"ABCDEFGHIJK".Contains(opcion))
                    {
                        Console.WriteLine("Opción inválida.");
                        return;
                    }

                    EliminarDatoEspecifico(index, opcion);
                    Console.WriteLine("Dato eliminado exitosamente.");
                }
                else if (eleccion == "R")
                {
                    Console.Write("¿Está seguro de que desea eliminar este registro completo? (S/N): ");
                    string respuesta = Console.ReadLine().ToUpper();
                    if (respuesta == "S")
                    {
                        EliminarRegistro(index);
                        Console.WriteLine("Registro eliminado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Eliminación cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar pagos: {ex.Message}");
            }
        }

        private static void EliminarDatoEspecifico(int index, string opcion)
        {
            switch (opcion)
            {
                case "A": fechaPago[index] = string.Empty; break;
                case "B": horaPago[index] = string.Empty; break;
                case "C": cedula[index] = string.Empty; break;
                case "D": nombre[index] = string.Empty; break;
                case "E": apellido1[index] = string.Empty; break;
                case "F": apellido2[index] = string.Empty; break;
                case "G": tipoServicio[index] = 0; break;
                case "H": numeroFactura[index] = string.Empty; break;
                case "I": montoPagar[index] = 0M; break;
                case "J": montoPagaCliente[index] = 0M; break;
                case "K": numeroCaja[index] = 0; break;
                // Añadir más casos según sea necesario
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
        private static void EliminarRegistro(int index)
        {
            // Desplazando cada elemento una posición hacia arriba desde el índice hasta el final de los registros
            for (int i = index; i < contadorPagos - 1; i++)
            {
                numeroPago[i] = numeroPago[i + 1];
                fechaPago[i] = fechaPago[i + 1];
                horaPago[i] = horaPago[i + 1];
                cedula[i] = cedula[i + 1];
                nombre[i] = nombre[i + 1];
                apellido1[i] = apellido1[i + 1];
                apellido2[i] = apellido2[i + 1];
                numeroCaja[i] = numeroCaja[i + 1];
                tipoServicio[i] = tipoServicio[i + 1];
                numeroFactura[i] = numeroFactura[i + 1];
                montoPagar[i] = montoPagar[i + 1];
                montoComision[i] = montoComision[i + 1];
                montoDeducido[i] = montoDeducido[i + 1];
                montoPagaCliente[i] = montoPagaCliente[i + 1];
                vuelto[i] = vuelto[i + 1];
            }

            // Decrementando el contador de pagos para reflejar la eliminación del registro
            contadorPagos--;

            // Limpiando el último elemento de cada array, ahora redundante después del decremento de contadorPagos
            int lastIndex = contadorPagos; // Nuevo índice del último elemento
            fechaPago[lastIndex] = string.Empty;
            horaPago[lastIndex] = string.Empty;
            cedula[lastIndex] = string.Empty;
            nombre[lastIndex] = string.Empty;
            apellido1[lastIndex] = string.Empty;
            apellido2[lastIndex] = string.Empty;
            numeroCaja[lastIndex] = 0;
            tipoServicio[lastIndex] = 0;
            numeroFactura[lastIndex] = string.Empty;
            montoPagar[lastIndex] = 0M;
            montoComision[lastIndex] = 0M;
            montoDeducido[lastIndex] = 0M;
            montoPagaCliente[lastIndex] = 0M;
            vuelto[lastIndex] = 0M;
        }


    }
}
