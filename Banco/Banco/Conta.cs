using System;
using System.Collections.Generic;

abstract class Conta
{
    //Propriedades
    public double NumeroConta { get; private set; }
    //Enum de tipo Conta
    public TipoConta TipoConta { get; private set; }
    private double Saldo { get; set; }
    public string Nome { get; private set; }
    private long CPF { get; set; }
    private DateTime DataNascimento { get; set; }

    //As mensagens de transferencia, saque e depósito serão armazenadas aqui independente da conta
    List<string> extratoBancario = new List<string>();

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
    public bool SacarDinheiro(double valorSaque)
    {
        if (this.Saldo - valorSaque <= 0)
        {
            Console.WriteLine("Saldo insuficiente!");
            return false;
        }

        this.Saldo -= valorSaque;

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

    public virtual void CalcularValorTarifaManutencao(TipoConta tipoConta)
    {
        //TODO
    }

    //Percorre a List e exibindo o número da conta, saldo atual e as mensagens de saque, depósito e transferência, independentemente da conta
    public virtual void ExtratoBancario()
    {
        Console.WriteLine($"Número da conta: {NumeroConta} Saldo Atual: {Saldo}");
        foreach (string extrato in extratoBancario)
        {
            Console.WriteLine($"- {extrato}");
        }
    }
}
