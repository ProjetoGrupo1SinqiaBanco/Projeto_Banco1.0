using System;

class ContaInvestimento : Conta
{
    public int PerfilInvestidor { get; set; }

    //retirar propriedade e adicionar no construtor
    public int perfilInvestidor;

    public ContaInvestimento(TipoConta tipoConta, double numeroConta, double saldo, string nome,
                            long cpf, DateTime dataNascimento) : base(tipoConta, numeroConta, saldo, nome, cpf, dataNascimento)
    {
    }

    //Método de investir em ações
    public void InvestirEmAcoes()
    {
        //TODO
    }

    //Método inicial de Simular um
    public string SimulaPerfilInvestidor()
    {
        Console.WriteLine("Selecione abaixo qual o seu perfil de investidor: ");

        Console.WriteLine("1 - Conservador: Segurança é seu bem mais precioso.");
        Console.WriteLine("2 - Moderado: Gosta de investir de forma segura, mas também está disposto a se aventurar um pouco.");
        Console.WriteLine("3 - Arrojado: O maior risco é não correr riscos.");

        int perfilInvestidor = int.Parse(Console.ReadLine());

        switch (perfilInvestidor)
        {
            case 1:
                return "Conservador";

            case 2:
                return "Moderado";

            case 3:
                return "Arrojado";

        }

        return "Perfil inválido";
    }

    //Implementar a sobrescrita do método Extrato de Conta Investimento
    public override void ExtratoBancario()
    {
        Console.WriteLine("Extrato da conta investimento");
        base.ExtratoBancario();
    }

}
