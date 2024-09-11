using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_bancario
{
    public class Banco
    {
        private List<Cliente> clientes;

        public Banco()
        {
            clientes = new List<Cliente>();
        }

        public void AgregarCliente(Cliente cliente)
        {
            clientes.Add(cliente);
        }

        public Cliente BuscarCliente(string numeroIdentificacion)
        {
            var cliente = clientes.Find(cliente => cliente.NumeroIdentificacion == numeroIdentificacion);
            if (cliente == null)
            {
                throw new InvalidOperationException("Cliente no encontrado.");
            }
            return cliente;
        }

        public CuentaBancaria BuscarCuenta(string numeroIdentificacion, string numeroCuenta)
        {
            Cliente cliente = BuscarCliente(numeroIdentificacion);
            var cuenta = cliente.ObtenerCuenta(numeroCuenta);
            if (cuenta == null)
            {
                throw new InvalidOperationException("Cuenta no encontrada.");
            }
            return cuenta;
        }

        public void RealizarOperacion(string numeroIdentificacion, string numeroCuenta, decimal monto, bool esDeposito)
        {
            CuentaBancaria cuenta = BuscarCuenta(numeroIdentificacion, numeroCuenta);
            if (esDeposito)
            {
                cuenta.Depositar(monto);
            }
            else
            {
                cuenta.Retirar(monto);
            }
        }

        public void Transferir(string numeroCuentaOrigen, string numeroCuentaDestino, decimal monto)
        {
            CuentaBancaria cuentaOrigen = clientes.SelectMany(c => c.ObtenerCuentas()).FirstOrDefault(c => c.NumeroCuenta == numeroCuentaOrigen);
            CuentaBancaria cuentaDestino = clientes.SelectMany(c => c.ObtenerCuentas()).FirstOrDefault(c => c.NumeroCuenta == numeroCuentaDestino);

            if (cuentaOrigen == null)
            {
                throw new InvalidOperationException("Cuenta origen no encontrada.");
            }

            if (cuentaDestino == null)
            {
                throw new InvalidOperationException("Cuenta destino no encontrada.");
            }

            cuentaOrigen.Transferir(cuentaDestino, monto);
        }
    }
}