using System;

class ContaPoupanca : Conta
{
    private double SaldoMinimo { get; set; }

    //Construtor da classe
    public ContaPoupanca(TipoConta tipoConta, double numeroConta, double saldo,
                        string nome, int cpf, DateTime dataNascimento, double saldoMinimo) : base(tipoConta, numeroConta, saldo, nome, cpf, dataNascimento)
    {
        this.SaldoMinimo = saldoMinimo;
    }

    //Implementar o método TransferenciaParaPoupanca
    public void TransferirParaPoupança()
    {
    }
}
