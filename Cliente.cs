using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_bancario
{
    public class Cliente
    {
        public string Nombre { get; }
        public string Apellido { get; }
        public string NumeroIdentificacion { get; }
        private List<CuentaBancaria> cuentas;

        public Cliente(string nombre, string apellido, string numeroIdentificacion)
        {
            Nombre = nombre;
            Apellido = apellido;
            NumeroIdentificacion = numeroIdentificacion;
            cuentas = new List<CuentaBancaria>();
        }

        public void AgregarCuenta(CuentaBancaria cuenta)
        {
            cuentas.Add(cuenta);
        }

        public List<CuentaBancaria> ObtenerCuentas()
        {
            return cuentas;
        }

        public CuentaBancaria ObtenerCuenta(string numeroCuenta)
        {
            return cuentas.Find(c => c.NumeroCuenta == numeroCuenta);
        }
    }
}
