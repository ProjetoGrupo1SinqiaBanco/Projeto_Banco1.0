using System;
using System.Collections.Generic;
using System.Threading;
using Banco;

class BancoMain
{
    public static void Main(string[] args)
    {
        string opcaoDoUsuario = MetodosAuxiliares.ObterOpcaoDoUsuario();

        while (opcaoDoUsuario != "E")
        {
            switch (opcaoDoUsuario)
            {
                case "1":
                    MetodosAuxiliares.CadastrarConta();
                    break;
                case "2":
                    MetodosAuxiliares.ListarContas();
                    break;
                case "3":
                    MetodosAuxiliares.Transferir();
                    break;
                case "4":
                    MetodosAuxiliares.Sacar();
                    break;
                case "5":
                    MetodosAuxiliares.Depositar();
                    break;
                case "6":
                    MetodosAuxiliares.VerExtrato();
                    break;
                case "C":
                    Console.Clear();
                    break;
                case "E":
                    return;
            }
            opcaoDoUsuario = MetodosAuxiliares.ObterOpcaoDoUsuario();
        }

        Console.WriteLine("Obrigado(a) por utilizar nossos serviços, até breve!!");
        Console.ReadLine();
    }
}