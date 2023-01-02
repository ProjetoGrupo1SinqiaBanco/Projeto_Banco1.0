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
            this.Saldo -= valor;
            this.Ação += valor;
            empresa.ValorPapeisDisponiveis -= valor;
            Console.WriteLine($"Você investiu {valor} reais em ações da {empresa.NomeEmpresa}");
            Console.WriteLine($"teste {empresa.ValorPapeisDisponiveis}");
        }
        else
        {
            Console.WriteLine("Não foi possível aplicar o investimento por saldo insulficiente");
        }

        //Adiciona a mensagem na List extratoBancario
        string mensagemExtratoDeposito = $"Investimento de R${valor} reais realizado com sucesso na empresa {empresa.NomeEmpresa}";
        extratoBancario.Add(mensagemExtratoDeposito);

    }

    //Método inicial de Simular um perfil de investidor
    public string SimulaPerfilInvestidor()
    {
        char resposta1, resposta2, resposta3;
        bool sucesso;

        Console.Clear();
        Console.WriteLine("Simule seu perfil de investidor: ");

        //1° pergunta/resposta e validação da entrada de dados
        do
        {
            Console.WriteLine("Toma maiores riscos ao investir seu dinheiro? (s/n)");
            sucesso = char.TryParse(Console.ReadLine().ToLower(), out resposta1);

            if (!sucesso || (resposta1 != 'n' && resposta1 != 's'))
            {
                Console.WriteLine("Por Favor, digite s para SIM e n para NÃO\n");
            }
        } while (!sucesso || (resposta1 != 'n' && resposta1 != 's'));

        //2° pergunta/resposta e validação da entrada de dados
        do
        {
            Console.WriteLine("Busca ganhos a longo prazo? (s/n)");
            sucesso = char.TryParse(Console.ReadLine().ToLower(), out resposta2);

            if (!sucesso || (resposta2 != 'n' && resposta2 != 's'))
            {
                Console.WriteLine("Por Favor, digite s para SIM e n para NÃO\n");
            }
        } while (!sucesso || (resposta2 != 'n' && resposta2 != 's'));

        //3° pergunta/resposta e validação da entrada de dados
        do
        {
            Console.WriteLine("Tem maiores conhecimentos do mercado financeiro e abre mão de maiores seguranças? (s/n)");
            sucesso = char.TryParse(Console.ReadLine().ToLower(), out resposta3);

            if (!sucesso || (resposta3 != 'n' && resposta3 != 's'))
            {
                Console.WriteLine("Por Favor, digite s para SIM e n para NÃO\n");
            }
        } while (!sucesso || (resposta3 != 'n' && resposta3 != 's'));

        //Teste para descobrir o perfil do usuario
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
        Console.WriteLine("3 - Arrojado: O maior risco é não correr riscos.\n");

        //Validação da entrada de dados
        int perfilInvestidor;
        do
        {
            sucesso = int.TryParse(Console.ReadLine(), out perfilInvestidor);

            if (!sucesso || perfilInvestidor > 3 || perfilInvestidor < 1)
            {
                Console.WriteLine("Por Favor, digite 1 para Conservador, 2 para Moderado e 3 para Arrojado\n");  
            }
        } while (!sucesso || perfilInvestidor > 3 || perfilInvestidor < 1);

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
