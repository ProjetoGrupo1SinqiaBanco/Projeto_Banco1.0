using System;
using System.Collections.Generic;
using System.Threading;

class ContaSalario : Conta
{
    //Propriedades
    public int CNPJPagador { get; set; }
    private string NomeEmpresa { get; set; }
    public double Salario { get; private set; }

    //construtor
    public ContaSalario(TipoConta tipoConta, double numeroConta, double saldo, string nome,
                        long cpf, DateTime dataNascimento, string nomeEmpresa, int cnpj, double salario) : base(tipoConta, numeroConta, saldo, nome, cpf, dataNascimento)
    {
        //validação do holerite
        Console.Clear();

        Console.WriteLine("Entre com seu holerite:");
        Console.Write("Nome funcionário:");
        string nomePessoalHolerite = Console.ReadLine();

        Console.Write("Nome da empresa:");
        string nomeEmpresaHolerite = Console.ReadLine();

        Console.WriteLine("CNPJ da empresa:");
        int cnpjHolerite = int.Parse(Console.ReadLine());

        Console.WriteLine("Salário:");
        double salarioHolerite = int.Parse(Console.ReadLine());

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
    public void DepositarSalario(double valorDepositado, int ID, int cnpj)
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

}