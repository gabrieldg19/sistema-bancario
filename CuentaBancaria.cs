using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_bancario
{
    public class CuentaBancaria
    {
        public string NumeroCuenta { get; }
        public decimal Saldo { get; private set; }
        private Cliente propietario;

        public CuentaBancaria(string numeroCuenta, Cliente propietario)
        {
            NumeroCuenta = numeroCuenta;
            this.propietario = propietario;
            Saldo = 0;
        }

        public void Depositar(decimal monto)
        {
            if (monto > 0)
            {
                Saldo += monto;
            }
            else
            {
                throw new ArgumentException("El monto debe ser positivo.");
            }
        }

        public void Retirar(decimal monto)
        {
            if (monto > 0 && Saldo >= monto)
            {
                Saldo -= monto;
            }
            else
            {
                throw new InvalidOperationException("Fondos insuficientes o monto inválido.");
            }
        }

        public void Transferir(CuentaBancaria cuentaDestino, decimal monto)
        {
            if (cuentaDestino == null)
            {
                throw new ArgumentNullException(nameof(cuentaDestino));
            }

            if (monto > 0 && Saldo >= monto)
            {
                Retirar(monto);
                cuentaDestino.Depositar(monto);
            }
            else
            {
                throw new InvalidOperationException("Fondos insuficientes o monto inválido.");
            }
        }
    }
}
