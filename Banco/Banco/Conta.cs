using System;
using System.Collections.Generic;

abstract class Conta
{
    //Propriedades
    public double NumeroConta { get; private set; }
    //Enum de tipo Conta
    public TipoConta TipoConta { get; private set; }
    public double Saldo { get; protected set; }
    public string Nome { get; private set; }
    private long CPF { get; set; }
    private DateTime DataNascimento { get; set; }

    //As mensagens de transferencia, saque e depósito serão armazenadas aqui independente da conta
    protected List<string> extratoBancario = new List<string>();

    //Construtor da classe Conta
    public Conta(TipoConta tipoConta, double numeroConta, double saldo, string nome, long cpf, DateTime dataNascimento)
    {
        this.NumeroConta = numeroConta;
        this.TipoConta = tipoConta;
        this.Saldo = saldo;
        this.Nome = nome;
        this.CPF = cpf;
        this.DataNascimento = dataNascimento;
    }

    //Métodos

    //Verifica o saldo atual da conta antes de realizar o saque
    public virtual bool SacarDinheiro(double valorSaque)
    {
        if (this.Saldo - valorSaque <= 0)
        {
            Console.WriteLine("Saldo insuficiente!");
            return false;
        }
        valorSaque = Math.Round(valorSaque,2);
        this.Saldo -= valorSaque;
        this.Saldo = Math.Round(this.Saldo,2);

        Console.WriteLine($"Saque de R${valorSaque} reais realizado com sucesso");

        //Adiciona a mensagem na List extratoBancario
        string mensagemExtratoSaque = $"Saque de R${valorSaque} reais realizado com sucesso da conta {NumeroConta}";
        extratoBancario.Add(mensagemExtratoSaque);
        return true;
    }

    public void DepositarDinheiro(double valorDeposito)
    {
        Console.Clear();
        this.Saldo += valorDeposito;

        Console.WriteLine($"Depósito de R${valorDeposito} reais realizado com sucesso na conta {NumeroConta}" +
        $"\nSaldo de {this.Saldo} reais");

        //Adiciona a mensagem na List extratoBancario
        string mensagemExtratoDeposito = $"Depósito de R${valorDeposito} reais realizado com sucesso na conta {NumeroConta}";
        extratoBancario.Add(mensagemExtratoDeposito);
    }

    //Obrigatório inserir o valor a ser transferido e a conta destino no parametro, verifica também se a conta tem saldo suficiente
    public virtual void TransferirDinheiro(double valorTransferencia, Conta contaDestino)
    {
        if (this.Saldo - valorTransferencia <= 0)
        {
            Console.WriteLine("Saldo insuficiente!");
        }

        this.Saldo -= valorTransferencia;

        contaDestino.DepositarDinheiro(valorTransferencia);

        //Adiciona a mensagem na List extratoBancario
        string mensagemExtratoTransferencia = $"Transferencia de R${valorTransferencia} reais realizado com sucesso para a conta {contaDestino.NumeroConta}";
        extratoBancario.Add(mensagemExtratoTransferencia);
    }

    public virtual double CalcularValorTarifaManutencao(TipoConta tipoDaConta)
    {
        double taxaSaque = 0;

        if (tipoDaConta == TipoConta.ContaPoupanca)
        {
            taxaSaque = 0.35;
            this.Saldo -= Math.Round(0.35,2);
        }
        else if (tipoDaConta == TipoConta.ContaSalario)
        {
            taxaSaque = 0.30;
            this.Saldo -= Math.Round(0.30,2);
        }
        else if (tipoDaConta == TipoConta.ContaInvestimento)
        {
            taxaSaque = 0.80;
            this.Saldo -= Math.Round(0.80,2);
        }
        return taxaSaque;
    }

    //Percorre a List e exibindo o número da conta, saldo atual e as mensagens de saque, depósito e transferência, independentemente da conta
    public virtual void ExtratoBancario()
    {
        Console.WriteLine($"Número da conta: {NumeroConta}\nSaldo Atual: R${Saldo}\n");
        foreach (string extrato in extratoBancario)
        {
            Console.WriteLine($"- {extrato}");
        }
    }
}
