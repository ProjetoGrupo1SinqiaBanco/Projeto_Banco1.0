using System;

class ContaInvestimento : Conta
{
    public string PerfilInvestidor { get; private set; }
    public double Ação { get; set; }

    //retirar propriedade e adicionar no construtor
    //public string perfilInvestidor;

    public ContaInvestimento(TipoConta tipoConta, double numeroConta, double saldo, string nome,
                            long cpf, DateTime dataNascimento) : base(tipoConta, numeroConta, saldo, nome, cpf, dataNascimento)
    {
    }

    //Método de investir em ações, aplicar o metodo para chamada no main, metodo está solto sem uso.
    public void InvestirEmAcoes(double valor, Mercado_de_Acoes empresa)
    {
        //TODO
        if (this.Saldo >= valor)
        {
            this.Ação += valor - empresa.ValorPapeisDisponiveis;
            Console.WriteLine($"Você investiu {valor} reais em ações da {empresa.NomeEmpresa}");
        }
        else
        {
            Console.WriteLine("Não foi possível aplicar o investimento por saldo insulficiente");
        }

    }

    //Método inicial de Simular um perfil de investidor
    public string SimulaPerfilInvestidor()
    {
        Console.Clear();
        Console.WriteLine("Simule seu perfil de investidor: ");

        char resposta1;
        do
        {
            Console.WriteLine("Toma maiores riscos ao investir seu dinheiro? (s/n)");
            resposta1 = char.Parse(Console.ReadLine());
        } while (resposta1 != 'n' && resposta1 != 's');

        char resposta2;
        do
        {
            Console.WriteLine("Busca ganhos a longo prazo? (s/n)");
            resposta2 = char.Parse(Console.ReadLine());
        } while (resposta2 != 'n' && resposta2 != 's');

        char resposta3;
        do
        {
            Console.WriteLine("Tem maiores conhecimentos do mercado financeiro e abre mão de maiores seguranças? (s/n)");
            resposta3 = char.Parse(Console.ReadLine());
        } while (resposta3 != 'n' && resposta3 != 's');

        Console.Clear();
        if (resposta1 == 'n' && resposta2 == 's' && resposta3 == 'n')
        {
            Console.WriteLine("Seu perfil é Conservador.");
        }
        else if (resposta1 == 'n' && resposta2 == 's' && resposta3 == 's')
        {
            Console.WriteLine("Seu perfil é Moderado.");
        }
        else if (resposta1 == 's' && resposta2 == 'n' && resposta3 == 's')
        {
            Console.WriteLine("Seu perfil é Arrojado.");
        }
        else if (resposta1 == 's' && resposta2 == 'n' && resposta3 == 'n')
        {
            Console.WriteLine("Seu perfil é Moderado.");
        }
        else if (resposta1 == 's' && resposta2 == 's' && resposta3 == 's')
        {
            Console.WriteLine("Seu perfil é Arrojado.");
        }
        else if (resposta1 == 'n' && resposta2 == 'n' && resposta3 == 'n')
        {
            Console.WriteLine("Seu perfil é Conservador.");
        }

        Console.WriteLine("\nBaseado em sua simulação de perfil, selecione o perfil de investimento desejado:\n");
        Console.WriteLine("1 - Conservador: Segurança é seu bem mais precioso.");
        Console.WriteLine("2 - Moderado: Gosta de investir de forma segura, mas também está disposto a se aventurar um pouco.");
        Console.WriteLine("3 - Arrojado: O maior risco é não correr riscos.");

        int perfilInvestidor = int.Parse(Console.ReadLine());

        switch (perfilInvestidor)
        {
            case 1:
                this.PerfilInvestidor = "Conservador";
                return "Conservador";

            case 2:
                this.PerfilInvestidor = "Moderado";
                return "Moderado";

            case 3:
                this.PerfilInvestidor = "Arrojado";
                return "Arrojado";

        }

        return "Perfil inválido";
    }

    //Implementar a sobrescrita do método Extrato de Conta Investimento
    public override void ExtratoBancario()
    {
        Console.WriteLine("Extrato - conta investimento");
        base.ExtratoBancario();
    }



}
