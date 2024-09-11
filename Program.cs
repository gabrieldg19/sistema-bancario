using System;
using System.Collections.Generic;

namespace sistema_bancario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banco banco = new Banco();
            Menu menu = new Menu(banco);
            menu.MostrarMenu();
        }
    }
}
