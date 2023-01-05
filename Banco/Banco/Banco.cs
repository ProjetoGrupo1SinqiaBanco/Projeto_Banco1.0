using System;
using System.Collections.Generic;
using System.Threading;
using Banco;

class BancoMain
{
    public static void Main(string[] args)
    {

        //Criação objetos da classe mercado de ações para uso no metodo de investir em ações.
        Mercado_de_Acoes empresa1 = new Mercado_de_Acoes("Industrias ACME", 1000000, 12345678912345);
        Mercado_de_Acoes empresa2 = new Mercado_de_Acoes("Loja de pão", 200000, 98765432198765);
        Mercado_de_Acoes empresa3 = new Mercado_de_Acoes("Mamaco Corp", 500000, 91764823579468);


        Console.WriteLine("\nBEM-VINDO AO BANCO!\n\nPara começar, crie uma conta.");
        Console.WriteLine("Pressione qualquer tecla para iniciar o cadastro.");
        Console.ReadKey();
        MetodosAuxiliares.CadastrarConta();

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
                case "7":
                    MetodosAuxiliares.ComprarAcoes(empresa1, empresa2, empresa3);
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

        Console.WriteLine();
    }
}