using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_bancario
{
    public class OperacionesBanco
    {
        private Banco banco;

        public OperacionesBanco(Banco banco)
        {
            this.banco = banco;
        }

        public void CrearCliente()
        {
            try
            {
                Console.Write("Ingrese nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese apellido: ");
                string apellido = Console.ReadLine();

                Console.Write("Ingrese número de identificación: ");
                string numeroIdentificacion = Console.ReadLine();

                Cliente cliente = new Cliente(nombre, apellido, numeroIdentificacion);

                Console.Write("Ingrese número de cuenta: ");
                string numeroCuenta = Console.ReadLine();
                CuentaBancaria cuenta = new CuentaBancaria(numeroCuenta, cliente);
                cliente.AgregarCuenta(cuenta);

                banco.AgregarCliente(cliente);

                Console.WriteLine("Cliente y cuenta registrados con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cliente: {ex.Message}");
            }
        }

        public void RealizarDeposito()
        {
            try
            {
                Console.Write("Ingrese número de identificación del cliente: ");
                string numeroIdentificacion = Console.ReadLine();

                Console.Write("Ingrese número de cuenta: ");
                string numeroCuenta = Console.ReadLine();

                Console.Write("Ingrese monto a depositar: ");
                decimal monto = Convert.ToDecimal(Console.ReadLine());

                banco.RealizarOperacion(numeroIdentificacion, numeroCuenta, monto, true);
                Console.WriteLine("Depósito realizado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar depósito: {ex.Message}");
            }
        }

        public void RealizarRetiro()
        {
            try
            {
                Console.Write("Ingrese número de identificación del cliente: ");
                string numeroIdentificacion = Console.ReadLine();

                Console.Write("Ingrese número de cuenta: ");
                string numeroCuenta = Console.ReadLine();

                Console.Write("Ingrese monto a retirar: ");
                decimal monto = Convert.ToDecimal(Console.ReadLine());

                banco.RealizarOperacion(numeroIdentificacion, numeroCuenta, monto, false);
                Console.WriteLine("Retiro realizado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar retiro: {ex.Message}");
            }
        }

        public void RealizarTransferencia()
        {
            try
            {
                Console.Write("Ingrese número de cuenta origen: ");
                string numeroCuentaOrigen = Console.ReadLine();

                Console.Write("Ingrese número de cuenta destino: ");
                string numeroCuentaDestino = Console.ReadLine();

                Console.Write("Ingrese monto a transferir: ");
                decimal monto = Convert.ToDecimal(Console.ReadLine());

                banco.Transferir(numeroCuentaOrigen, numeroCuentaDestino, monto);
                Console.WriteLine("Transferencia realizada con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar transferencia: {ex.Message}");
            }
        }

        public void ConsultarSaldo()
        {
            try
            {
                Console.Write("Ingrese número de identificación del cliente: ");
                string numeroIdentificacion = Console.ReadLine();

                Console.Write("Ingrese número de cuenta: ");
                string numeroCuenta = Console.ReadLine();

                decimal saldo = banco.BuscarCuenta(numeroIdentificacion, numeroCuenta).Saldo;
                Console.WriteLine($"El saldo de la cuenta es: {saldo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al consultar saldo: {ex.Message}");
            }
        }
    }
}
