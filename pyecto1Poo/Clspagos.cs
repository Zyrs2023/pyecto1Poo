using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
                Console.WriteLine(new string('=', 50));
                Console.WriteLine("SISTEMA DE PAGOS - REALIZAR PAGO");
                Console.WriteLine(new string('=', 50));

                if (contadorPagos >= MaxPagos)
                {
                    Console.WriteLine("\n[Error] Los vectores están llenos. No se pueden realizar más pagos.\n");
                    return;
                }

                // Lógica para ingresar los detalles del pago
                string input;

                do
                {
                    input = LeerEntradaValida("\nIngrese la Cédula (solo números): ", esNumerica: true);
                    if (string.IsNullOrWhiteSpace(input))
                        Console.WriteLine("La cédula no puede quedar en blanco.");
                } while (string.IsNullOrWhiteSpace(input));
                cedula[contadorPagos] = input;

                do
                {
                    input = LeerEntradaValida("Ingrese el Nombre: ", esNumerica: false);
                    if (string.IsNullOrWhiteSpace(input))
                        Console.WriteLine("El nombre no puede quedar en blanco.");
                } while (string.IsNullOrWhiteSpace(input));
                nombre[contadorPagos] = input;

                do
                {
                    input = LeerEntradaValida("Ingrese el primer apellido: ", esNumerica: false);
                    if (string.IsNullOrWhiteSpace(input))
                        Console.WriteLine("El primer apellido no puede quedar en blanco.");
                } while (string.IsNullOrWhiteSpace(input));
                apellido1[contadorPagos] = input;

                do
                {
                    input = LeerEntradaValida("Ingrese el segundo apellido: ", esNumerica: false);
                    if (string.IsNullOrWhiteSpace(input))
                        Console.WriteLine("El segundo apellido no puede quedar en blanco.");
                } while (string.IsNullOrWhiteSpace(input));
                apellido2[contadorPagos] = input;

                Console.WriteLine("\nTipo de Servicio (1= Luz, 2= Teléfono, 3= Agua): ");
                while (!int.TryParse(Console.ReadLine(), out tipoServicio[contadorPagos]) || tipoServicio[contadorPagos] < 1 || tipoServicio[contadorPagos] > 3)
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entre 1 y 3:");
                }

                do
                {
                    input = LeerEntradaValida("Ingrese el Número de Factura: ", esNumerica: true);
                    if (string.IsNullOrWhiteSpace(input))
                        Console.WriteLine("El número de factura no puede quedar en blanco.");
                } while (string.IsNullOrWhiteSpace(input));
                numeroFactura[contadorPagos] = input;

                do
                {
                    Console.WriteLine("Ingrese el Monto a Pagar: ");
                    input = Console.ReadLine();
                    if (!decimal.TryParse(input, out montoPagar[contadorPagos]) || montoPagar[contadorPagos] <= 0)
                        Console.WriteLine("Entrada inválida. Por favor, ingrese un monto válido y positivo:");
                } while (!decimal.TryParse(input, out montoPagar[contadorPagos]) || montoPagar[contadorPagos] <= 0);

                CalcularComisiones(contadorPagos);

                do
                {
                    Console.WriteLine("Ingrese el Monto que Paga el Cliente: ");
                    input = Console.ReadLine();
                    if (!decimal.TryParse(input, out montoPagaCliente[contadorPagos]) || montoPagaCliente[contadorPagos] < montoPagar[contadorPagos])
                        Console.WriteLine("El monto pagado no puede ser menor al monto a pagar. Por favor, intente de nuevo:");
                } while (!decimal.TryParse(input, out montoPagaCliente[contadorPagos]) || montoPagaCliente[contadorPagos] < montoPagar[contadorPagos]);
                vuelto[contadorPagos] = montoPagaCliente[contadorPagos] - montoPagar[contadorPagos];

                numeroPago[contadorPagos] = contadorPagos + 1;
                fechaPago[contadorPagos] = DateTime.Now.ToString("dd/MM/yyyy");
                horaPago[contadorPagos] = DateTime.Now.ToString("HH:mm");

                numeroCaja[contadorPagos] = new Random().Next(1, 4);

                contadorPagos++;
                MostrarPago(contadorPagos - 1);

                Console.WriteLine("\n[Pago Realizado Exitosamente]\n");

                Console.WriteLine(new string('-', 50));
                Console.Write("¿Desea Realizar otro pago ? (S/N): ");
                var continuar = Console.ReadLine().ToUpper();
                if (continuar != "S")
                {
                    // Opcional: Lógica para terminar o continuar
                    return;
                }

                // Repetir el proceso si el usuario desea continuar
                RealizarPagos();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[Error] al realizar el pago: {ex.Message}\n");
            }
        }



        private static string LeerEntradaValida(string mensaje, bool esNumerica)
        {
            Console.WriteLine(mensaje);
            string entrada = Console.ReadLine();
            while ((esNumerica && !entrada.All(char.IsDigit)) || (!esNumerica && !entrada.Replace(" ", "").All(char.IsLetter)))
            {
                Console.WriteLine($"Entrada inválida. Por favor, ingrese una entrada {(esNumerica ? "numérica" : "alfabética")}.");

                Console.WriteLine(mensaje);
                entrada = Console.ReadLine();
            }
            return entrada;
        }

        private static void CalcularComisiones(int indice)
        {
            switch (tipoServicio[indice])
            {
                case 1:
                    montoComision[indice] = montoPagar[indice] * 0.04M;
                    break;
                case 2:
                    montoComision[indice] = montoPagar[indice] * 0.055M;
                    break;
                case 3:
                    montoComision[indice] = montoPagar[indice] * 0.065M;
                    break;
                default:
                    Console.WriteLine("Tipo de servicio no reconocido.");
                    break;
            }
            montoDeducido[indice] = montoPagar[indice] - montoComision[indice];
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
                
            } catch (Exception ex)
            {
                Console.WriteLine($"Error al mostrar el pago: {ex.Message}");
            }
        }

        public static void ConsultarPagos()
        {
            bool realizarOtraConsulta = true;
            while (realizarOtraConsulta)
            {
                try
                {

                    Console.Clear(); // Limpiar la consola antes de cada consulta
                    Console.WriteLine("Seleccione el dato por el cual desea buscar la factura:");
                    Console.WriteLine("A - Número de Pago");
                    Console.WriteLine("B - Fecha");
                    Console.WriteLine("C - Hora");
                    Console.WriteLine("D - Cédula");
                    Console.WriteLine("E - Nombre");
                    Console.WriteLine("F - Apellido1");
                    Console.WriteLine("G - Apellido2");
                    Console.WriteLine("H - Tipo de Servicio");
                    Console.WriteLine("I - Número de Factura");
                    Console.WriteLine("J - Monto a Pagar");
                    Console.WriteLine("K - Monto Comisión");
                    Console.WriteLine("L - Monto Deducido");
                    Console.WriteLine("M - Monto que Paga Cliente");
                    Console.WriteLine("N - Vuelto");
                    Console.WriteLine("O - Número de Caja");
                    Console.Write("Opción: ");
                    string opcionBusqueda = Console.ReadLine().ToUpper();

                    switch (opcionBusqueda)
                    {
                        case "A":
                            ConsultarPorNumeroPago();
                            break;
                        case "B":
                            ConsultarPorFecha();
                            break;
                        case "C":
                            ConsultarPorHora();
                            break;
                        case "D":
                            ConsultarPorCedula();
                            break;
                        case "E":
                            ConsultarPorNombre();
                            break;
                        case "F":
                            ConsultarPorApellido1();
                            break;
                        case "G":
                            ConsultarPorApellido2();
                            break;
                        case "H":
                            ConsultarPorTipoServicio();
                            break;
                        case "I":
                            ConsultarPorNumeroFactura();
                            break;
                        case "J":
                            ConsultarPorMontoPagar();
                            break;
                        case "K":
                            ConsultarPorMontoComision();
                            break;
                        case "L":
                            ConsultarPorMontoDeducido();
                            break;
                        case "M":
                            ConsultarPorMontoPagaCliente();
                            break;
                        case "N":
                            ConsultarPorVuelto();
                            break;
                        case "O":
                            ConsultarPorNumeroCaja();
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }

                    Console.Write("¿Desea realizar otra consulta? (S/N): ");
                    string respuesta = Console.ReadLine().ToUpper();
                    if (respuesta != "S")
                    {
                        realizarOtraConsulta = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al consultar el pago: {ex.Message}");
                }
            }
        }

        private static void ConsultarPorNumeroPago()
        {
            Console.Write("Ingrese el número de pago a consultar: ");
            string numPagoInput = Console.ReadLine();
            if (int.TryParse(numPagoInput, out int numPago))
            {
                var indices = Enumerable.Range(0, numeroPago.Length)
                                        .Where(i => numeroPago[i] == numPago)
                                        .ToArray();
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Número de pago inválido.");
            }
        }

        private static void ConsultarPorFecha()
        {
            Console.Write("Ingrese la fecha a consultar (dd/MM/yyyy): ");
            string fechaInput = Console.ReadLine();
            if (DateTime.TryParseExact(fechaInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
                var indices = Enumerable.Range(0, fechaPago.Length)
                                        .Where(i => fechaPago[i] == fecha.ToString("dd/MM/yyyy"))
                                        .ToArray();
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Formato de fecha inválido.");
            }
        }

        private static void ConsultarPorHora()
        {
            Console.Write("Ingrese la hora a consultar (HH:mm): ");
            string horaInput = Console.ReadLine();
            if (DateTime.TryParseExact(horaInput, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime hora))
            {
                var indices = Enumerable.Range(0, horaPago.Length)
                                        .Where(i => horaPago[i] == hora.ToString("HH:mm"))
                                        .ToArray();
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Formato de hora inválido.");
            }
        }



        private static void ConsultarPorCedula()
        {
            Console.Write("Ingrese la cédula a consultar: ");
            string cedulaInput = Console.ReadLine();
            var indices = Enumerable.Range(0, cedula.Length)
                                    .Where(i => cedula[i] == cedulaInput)
                                    .ToArray();
            MostrarResultadoConsulta(indices);
        }

        private static void ConsultarPorNombre()
        {
            Console.Write("Ingrese el nombre a consultar: ");
            string nombreInput = Console.ReadLine().ToLower(); // Convertir la entrada a minúsculas
            var indices = Enumerable.Range(0, nombre.Length)
                                    .Where(i => nombre[i].ToLower() == nombreInput) // Convertir los nombres en el arreglo a minúsculas
                                    .ToArray();
            if (indices.Length > 0)
            {
                if (ValidarYActualizarTexto(indices[0], nombreInput, ref nombre[indices[0]], "Nombre inválido."))
                {
                    MostrarResultadoConsulta(indices);
                }
                else
                {
                    Console.WriteLine("Nombre inválido.");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron facturas con el nombre consultado.");
            }
        }

        private static void ConsultarPorApellido1()
        {
            Console.Write("Ingrese el primer apellido a consultar: ");
            string apellido1Input = Console.ReadLine().ToLower(); // Convertir la entrada a minúsculas
            var indices = Enumerable.Range(0, apellido1.Length)
                                    .Where(i => apellido1[i].ToLower() == apellido1Input) // Convertir los apellidos en el arreglo a minúsculas
                                    .ToArray();
            if (indices.Length > 0)
            {
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("No se encontraron facturas con el primer apellido consultado.");
            }
        }

        private static void ConsultarPorApellido2()
        {
            Console.Write("Ingrese el segundo apellido a consultar: ");
            string apellido2Input = Console.ReadLine().ToLower(); // Convertir la entrada a minúsculas
            var indices = Enumerable.Range(0, apellido2.Length)
                                    .Where(i => apellido2[i].ToLower() == apellido2Input) // Convertir los apellidos en el arreglo a minúsculas
                                    .ToArray();
            if (indices.Length > 0)
            {
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("No se encontraron facturas con el segundo apellido consultado.");
            }
        }


        private static void ConsultarPorTipoServicio()
        {
            Console.Write("Ingrese el tipo de servicio a consultar: ");
            string tipoServicioInput = Console.ReadLine();
            var indices = Enumerable.Range(0, tipoServicio.Length)
                                    .Where(i => tipoServicio[i] == int.Parse(tipoServicioInput))
                                    .ToArray();
            if (indices.Any())
            {
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Tipo de servicio no encontrado.");
            }
        }


        private static void ConsultarPorNumeroFactura()
        {
            Console.Write("Ingrese el número de factura a consultar: ");
            string numeroFacturaInput = Console.ReadLine();
            var indices = Enumerable.Range(0, numeroFactura.Length)
                                    .Where(i => numeroFactura[i] == numeroFacturaInput)
                                    .ToArray();
            MostrarResultadoConsulta(indices);
        }

        private static void ConsultarPorMontoPagar()
        {
            Console.Write("Ingrese el monto a pagar a consultar: ");
            string montoPagarInput = Console.ReadLine();
            var indices = Enumerable.Range(0, montoPagar.Length)
                                    .Where(i => montoPagar[i] == decimal.Parse(montoPagarInput))
                                    .ToArray();
            if (ValidarYActualizarMonto(-1, montoPagarInput, ref montoPagar[0], "Monto a pagar inválido."))
            {
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Monto a pagar inválido.");
            }
        }

        private static void ConsultarPorMontoComision()
        {
            Console.Write("Ingrese el monto de comisión a consultar: ");
            string montoComisionInput = Console.ReadLine();
            var indices = Enumerable.Range(0, montoComision.Length)
                                    .Where(i => montoComision[i] == decimal.Parse(montoComisionInput))
                                    .ToArray();
            if (ValidarYActualizarMonto(-1, montoComisionInput, ref montoComision[0], "Monto de comisión inválido."))
            {
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Monto de comisión inválido.");
            }
        }

        private static void ConsultarPorMontoDeducido()
        {
            Console.Write("Ingrese el monto deducido a consultar: ");
            string montoDeducidoInput = Console.ReadLine();
            var indices = Enumerable.Range(0, montoDeducido.Length)
                                    .Where(i => montoDeducido[i] == decimal.Parse(montoDeducidoInput))
                                    .ToArray();
            if (ValidarYActualizarMonto(-1, montoDeducidoInput, ref montoDeducido[0], "Monto deducido inválido."))
            {
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Monto deducido inválido.");
            }
        }

        private static void ConsultarPorMontoPagaCliente()
        {
            Console.Write("Ingrese el monto que paga el cliente a consultar: ");
            string montoPagaClienteInput = Console.ReadLine();
            var indices = Enumerable.Range(0, montoPagaCliente.Length)
                                    .Where(i => montoPagaCliente[i] == decimal.Parse(montoPagaClienteInput))
                                    .ToArray();
            if (ValidarYActualizarMonto(-1, montoPagaClienteInput, ref montoPagaCliente[0], "Monto que paga el cliente inválido."))
            {
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Monto que paga el cliente inválido.");
            }
        }

        private static void ConsultarPorVuelto()
        {
            Console.Write("Ingrese el vuelto a consultar: ");
            string vueltoInput = Console.ReadLine();
            var indices = Enumerable.Range(0, vuelto.Length)
                                    .Where(i => vuelto[i] == decimal.Parse(vueltoInput))
                                    .ToArray();
            if (ValidarYActualizarMonto(-1, vueltoInput, ref vuelto[0], "Vuelto inválido."))
            {
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Vuelto inválido.");
            }
        }

        private static void ConsultarPorNumeroCaja()
        {
            Console.Write("Ingrese el número de caja a consultar: ");
            string numeroCajaInput = Console.ReadLine();
            var indices = Enumerable.Range(0, numeroCaja.Length)
                                    .Where(i => numeroCaja[i] == int.Parse(numeroCajaInput))
                                    .ToArray();
            if (indices.Any())
            {
                MostrarResultadoConsulta(indices);
            }
            else
            {
                Console.WriteLine("Número de caja no encontrado.");
            }
        }


        // Método para mostrar los resultados de la consulta
        private static void MostrarResultadoConsulta(IEnumerable<int> indices)
        {
            if (indices.Any())
            {
                Console.WriteLine("Resultados encontrados:");
                foreach (var index in indices)
                {
                    MostrarDatosPago(index);
                }
            }
            else
            {
                Console.WriteLine("No se encontraron facturas con el dato consultado.");
            }
        }



        public static void ModificarPagos()
        {
            try
            {
                Console.Write("Ingrese el número de pago a modificar: ");
                if (!int.TryParse(Console.ReadLine(), out int numPago))
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
                    Console.WriteLine("A - Fecha (dd/MM/yyyy)");
                    Console.WriteLine("B - Hora (HH:mm)");
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

                    bool datoValido = true; // Asumir que el dato es válido inicialmente

                    switch (opcion)
                    {
                        case "A": // Fecha
                            datoValido = ValidarYActualizarFecha(index, nuevoDato);
                            break;
                        case "B": // Hora
                            datoValido = ValidarYActualizarHora(index, nuevoDato);
                            break;
                        case "C": // Cedula
                            cedula[index] = nuevoDato; // Validación específica si es necesaria
                            break;
                        case "D": // Nombre
                            datoValido = ValidarYActualizarTexto(index, nuevoDato, ref nombre[index], "El nombre solo debe contener letras.");
                            break;
                        case "E": // Apellido1
                            datoValido = ValidarYActualizarTexto(index, nuevoDato, ref apellido1[index], "El apellido solo debe contener letras.");
                            break;
                        case "F": // Apellido2
                            datoValido = ValidarYActualizarTexto(index, nuevoDato, ref apellido2[index], "El apellido solo debe contener letras.");
                            break;
                        case "G": // Tipo de Servicio
                            datoValido = ValidarYActualizarTipoServicio(index, nuevoDato);
                            break;
                        case "H": // Numero de Factura
                            numeroFactura[index] = nuevoDato; // Validación específica si es necesaria
                            break;
                        case "I": // Monto a Pagar
                            datoValido = ValidarYActualizarMonto(index, nuevoDato, ref montoPagar[index], "Monto a pagar inválido.");
                            break;
                        case "J": // Monto que Paga Cliente
                            datoValido = ValidarYActualizarMonto(index, nuevoDato, ref montoPagaCliente[index], "Monto que paga el cliente inválido.", montoPagar[index]);
                            break;
                        case "K": // Número de Caja
                            datoValido = ValidarYActualizarNumeroCaja(index, nuevoDato);
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            datoValido = false;
                            break;
                    }

                    if (datoValido)
                    {
                        // Recalcular comisiones después de la modificación
                        CalcularComisiones(index);
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

       
        private static bool ValidarYActualizarFecha(int index, string nuevoDato)
        {
            if (DateTime.TryParseExact(nuevoDato, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
                fechaPago[index] = nuevoDato;
                return true;
            }
            else
            {
                Console.WriteLine("Formato de fecha inválido. Utilice el formato dd/MM/yyyy.");
                return false;
            }
        }
        private static bool ValidarYActualizarHora(int index, string nuevoDato)
        {
            if (DateTime.TryParseExact(nuevoDato, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime hora))
            {
                horaPago[index] = nuevoDato;
                return true;
            }
            else
            {
                Console.WriteLine("Formato de hora inválido. Utilice el formato HH:mm.");
                return false;
            }
        }
        private static bool ValidarYActualizarTexto(int index, string nuevoDato, ref string campo, string mensajeError)
        {
            if (nuevoDato.All(c => char.IsLetter(c) || c == ' '))
            {
                campo = nuevoDato;
                return true;
            }
            else
            {
                Console.WriteLine(mensajeError);
                return false;
            }
        }
        private static bool ValidarYActualizarTipoServicio(int index, string nuevoDato)
        {
            if (int.TryParse(nuevoDato, out int tipoServicio) && tipoServicio >= 1 && tipoServicio <= 3)
            {
                Clspagos.tipoServicio[index] = tipoServicio;
                return true;
            }
            else
            {
                Console.WriteLine("Número de tipo de servicio inválido. Debe ser entre 1 y 3.");
                return false;
            }
        }
        private static bool ValidarYActualizarMonto(int index, string nuevoDato, ref decimal campo, string mensajeError, decimal minimo = 0M)
        {
            if (decimal.TryParse(nuevoDato, out decimal monto) && monto >= minimo)
            {
                campo = monto;
                return true;
            }
            else
            {
                Console.WriteLine(mensajeError);
                return false;
            }
        }
        private static bool ValidarYActualizarNumeroCaja(int index, string nuevoDato)
        {
            if (int.TryParse(nuevoDato, out int numeroCaja) && numeroCaja >= 1 && numeroCaja <= 3)
            {
                Clspagos.numeroCaja[index] = numeroCaja;
                return true;
            }
            else
            {
                Console.WriteLine("Número de caja inválido. Debe ser entre 1 y 3.");
                return false;
            }
        }



        public static void EliminarPagos()
        {
            try
            {
                Console.Write("Ingrese el número de pago que desea eliminar: ");
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
                    EliminarDatoEspecifico(index);
                }
                else if (eleccion == "R")
                {
                    EliminarRegistroCompleto(index);
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                }

                Console.Write("¿Desea eliminar otro registro? (S/N): ");
                var eliminarOtro = Console.ReadLine().ToUpper();
                if (eliminarOtro == "S")
                {
                    EliminarPagos(); // Llamar recursivamente para eliminar otro registro
                }
                else
                {
                    // Si el usuario no quiere eliminar otro registro, salir de la función
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar pagos: {ex.Message}");
            }
        }


        private static void EliminarDatoEspecifico(int index)
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

            // Validación de la opción
            if (!"ABCDEFGHIJK".Contains(opcion))
            {
                Console.WriteLine("Opción inválida.");
                return;
            }

            // Ejemplo de cómo eliminar el dato específico "Fecha"
            switch (opcion)
            {
                case "A": fechaPago[index] = null; break;
                case "B": horaPago[index] = null; break;
                case "C": cedula[index] = null; break;
                case "D": nombre[index] = null; break;
                case "E": apellido1[index] = null; break;
                case "F": apellido2[index] = null; break;
                case "G": tipoServicio[index] = 0; break; // Considerar cómo manejar valores "eliminados" para tipos numéricos
                case "H": numeroFactura[index] = null; break;
                case "I": montoPagar[index] = 0; break;
                case "J": montoPagaCliente[index] = 0; break;
                case "K": numeroCaja[index] = 0; break;
                    // Añadir más casos según sea necesario
            }
            MostrarDatosPago(index);
            Console.WriteLine("Dato eliminado exitosamente.");
        }

        private static void EliminarRegistroCompleto(int index)
        {
            Console.Write("¿Está seguro de que desea eliminar este registro completo? (S/N): ");
            string respuesta = Console.ReadLine().ToUpper();
            if (respuesta == "S")
            {
                // Desplazar todos los elementos una posición hacia arriba para eliminar el registro
                for (int i = index; i < contadorPagos - 1; i++)
                {
                    numeroPago[i] = numeroPago[i + 1];
                    fechaPago[i] = fechaPago[i + 1];
                    horaPago[i] = horaPago[i + 1];
                    cedula[i] = cedula[i + 1];
                    nombre[i] = nombre[i + 1];
                    apellido1[i] = apellido1[i + 1];
                    apellido2[i] = apellido2[i + 1];
                    tipoServicio[i] = tipoServicio[i + 1];
                    numeroFactura[i] = numeroFactura[i + 1];
                    montoPagar[i] = montoPagar[i + 1];
                    montoComision[i] = montoComision[i + 1];
                    montoDeducido[i] = montoDeducido[i + 1];
                    montoPagaCliente[i] = montoPagaCliente[i + 1];
                    vuelto[i] = vuelto[i + 1];
                    numeroCaja[i] = numeroCaja[i + 1];
                }

                // Limpiar el último elemento, ahora redundante después de la eliminación
                int ultimo = contadorPagos - 1; // Índice del último elemento
                fechaPago[ultimo] = null;
                horaPago[ultimo] = null;
                cedula[ultimo] = null;
                nombre[ultimo] = null;
                apellido1[ultimo] = null;
                apellido2[ultimo] = null;
                tipoServicio[ultimo] = 0;
                numeroFactura[ultimo] = null;
                montoPagar[ultimo] = 0;
                montoComision[ultimo] = 0;
                montoDeducido[ultimo] = 0;
                montoPagaCliente[ultimo] = 0;
                vuelto[ultimo] = 0;
                numeroCaja[ultimo] = 0;

                contadorPagos--; // Disminuir el contador de registros
                MostrarDatosPago(index);
                Console.WriteLine("Registro eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Eliminación cancelada.");
            }
        }

    }
}
