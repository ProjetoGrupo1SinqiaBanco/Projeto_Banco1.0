using System;
using System.Collections.Generic;
using System.Threading;

class ContaSalario : Conta
{
    //Propriedades
    public long CNPJPagador { get; set; }
    private string NomeEmpresa { get; set; }
    public double Salario { get; private set; }

    //construtor
    public ContaSalario(TipoConta tipoConta, double numeroConta, double saldo, string nome,
                        long cpf, DateTime dataNascimento, string nomeEmpresa, long cnpj, double salario) : base(tipoConta, numeroConta, saldo, nome, cpf, dataNascimento)
    {
        string nomePessoalHolerite, nomeEmpresaHolerite;
        long cnpjHolerite;
        double salarioHolerite;
        bool sucesso;

        //VALIDAÇÃO DO HOLERITE
        Console.Clear();
        Console.WriteLine("Entre com seu HOLERITE:");

        Console.Write("Nome funcionário: ");
        nomePessoalHolerite = Console.ReadLine();

        Console.Write("Nome da empresa: ");
        nomeEmpresaHolerite = Console.ReadLine();

        //cnpj e validação da entrada de dados
        do
        {
            Console.Write("CNPJ da empresa: ");
            sucesso = long.TryParse(Console.ReadLine(), out cnpjHolerite);

            if (!sucesso)
            {
                Console.WriteLine("Por Favor, Digite apenas numeros\n");
                continue;
            }

            if (cnpjHolerite.ToString().Length != 14)
            {
                Console.WriteLine("Por Favor, digite um CNPJ valido (14 digitos)\n");
            }

        } while (cnpjHolerite.ToString().Length != 14);

        //salario e validação da entrada de dados
        do
        {
            Console.Write("Salário: ");
            sucesso = double.TryParse(Console.ReadLine(), out salarioHolerite);

            if (!sucesso)
            {
                Console.WriteLine("Por Favor, Digite apenas numeros\n");
                continue;
            }

            if (salarioHolerite <= 0)
            {
                Console.WriteLine("Por Favor, insira um salario valido (minimo R$00,01)");
            }

        } while (salarioHolerite <= 0);

        this.NomeEmpresa = nomeEmpresa;
        this.CNPJPagador = cnpj;
        this.Salario = salario;

        Console.WriteLine("Validando informações...");
        Thread.Sleep(2000);

        //valida se as informações inseridas batem com os dados do holerite
        if (nomePessoalHolerite != nome || CNPJPagador != cnpjHolerite || Salario != salarioHolerite || nomeEmpresaHolerite != nomeEmpresa)
        {
            //Seta a propriedade CNPJPagador como zero para validar que as informações não batem
            CNPJPagador = 0;
        }
    }

    //Método de depositar salario, testa se o cnpj que vai depositar é o mesmo cadastrado na conta salario e deposita o valor do salario do funcionario
    public void DepositarSalario(double valorDepositado, int ID, long cnpj)
    {

        //valida se o cnpj inserido é o mesmo do pagador
        if (cnpj == this.CNPJPagador)
        {
            this.DepositarDinheiro(valorDepositado);
            Console.WriteLine($"Deposito do salário realizado pelo CNPJ {cnpj}");
        }
        else
        {
            //caso haja divergencia de informação o deposito é interrompido
            Console.WriteLine("Não foi possivel fazer o depósito por divergência de informação" +
            "\nPressione qualquer tecla para continuar");
            Console.ReadKey();
        }
    }

    //método de ver holerite, deve ser mostrado o CNPJPagador, NomeEmpresa e Salario
    public void verHolerite()
    {
        Console.Clear();
        Console.WriteLine("HOLERITE");
        Console.WriteLine("------------");
        Console.WriteLine($"Nome do Funcionário: {this.Nome}");
        Console.WriteLine($"Nome da Empresa: {this.NomeEmpresa}");
        Console.WriteLine($"CNPJ da Empresa: {this.CNPJPagador}");
        Console.WriteLine($"Salário: {this.Salario}");
    }

    public override void ExtratoBancario()
    {
        Console.WriteLine("Extrato - conta salário");
        base.ExtratoBancario();
    }

}