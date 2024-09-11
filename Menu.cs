using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_bancario
{
    public class Menu
    {
        private Banco banco;
        private OperacionesBanco operacionesBanco;

        public Menu(Banco banco)
        {
            this.banco = banco;
            this.operacionesBanco = new OperacionesBanco(banco);
        }

        public void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- Menú Banco ---");
                Console.WriteLine("1. Registrar Cliente");
                Console.WriteLine("2. Depositar");
                Console.WriteLine("3. Retirar");
                Console.WriteLine("4. Transferir");
                Console.WriteLine("5. Consultar Saldo");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        operacionesBanco.CrearCliente();
                        break;
                    case "2":
                        operacionesBanco.RealizarDeposito();
                        break;
                    case "3":
                        operacionesBanco.RealizarRetiro();
                        break;
                    case "4":
                        operacionesBanco.RealizarTransferencia();
                        break;
                    case "5":
                        operacionesBanco.ConsultarSaldo();
                        break;
                    case "6":
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            }
        }
    }
}
