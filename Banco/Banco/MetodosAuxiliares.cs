using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco
{
    public class MetodosAuxiliares
    {
        //Armazena as contas criadas pelo usuário independentemente do tipo
        static List<Conta> listaContas = new List<Conta>();
        //Armazena as contas salarios criadas, contas que nao sao salario o indice armazena valor nulo.
        static List<ContaSalario> listaContaSalario = new List<ContaSalario>();

        public static void CadastrarConta()
    {
        int entradaTipoConta;
        long entradaCpf;
        double entradaNumeroConta = GerarNumeroConta();
        double entradaSaldoMinimo = 50 , entradaSaldo = 0;
        string entradaNome;
        DateTime entradaDataNascimento;
        bool sucesso, bug = false;

        try
        {
            Console.Clear();

            //Caso algum Erro de Conversão Aconteça
            if (bug)
            {
                Console.WriteLine("Um Erro Inesperado Aconteceu, Por Favor Cadastre Novamente");
            }

            Console.WriteLine("Cadastrar nova conta");

            //Tipo de Conta que o usuario quer criar e a Validação da entrada de dados
            do
            {
                Console.Write("Digite 1 para Conta Poupança | 2 para Conta Salário | 3 para Conta Investimento : ");
                sucesso = int.TryParse(Console.ReadLine(), out entradaTipoConta);

                if (!sucesso || entradaTipoConta > 3 || entradaTipoConta < 1)
                {
                    Console.WriteLine("Opção digitada não existe, Tente Novamente\n");
                }

            } while (!sucesso || entradaTipoConta > 3 || entradaTipoConta < 1);

            //Numero da Conta do usuario e a Validação da entrada de dados
           
                Console.Write($"O número da nova conta é: {entradaNumeroConta}");
                Console.WriteLine(string.Empty);

            while (!sucesso);

            //Nome do Titular
            Console.Write("Digite o nome do titular da conta: ");
            entradaNome = Console.ReadLine();

            //CPF do titular e Validação da entrada de dados
            do
            {
                Console.Write("Digite o CPF do titular da conta: ");
                sucesso = long.TryParse(Console.ReadLine(), out entradaCpf);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, utilize apenas numeros\n");
                    continue;
                }

                if (entradaCpf.ToString().Length != 11)
                {
                    Console.WriteLine("Por Favor, digite um CPF valido (11 digitos)\n");
                }

            } while (entradaCpf.ToString().Length != 11);

            //Data de Nascimento do Titular e Validação da entrada de dados
            do
            {
                Console.Write("Digite a data de nascimento do titular da conta (Dia/Mês/Ano): ");
                sucesso = DateTime.TryParse(Console.ReadLine(), out entradaDataNascimento);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite seguindo o seguinte modelo (colocando as barras tambem): Dia/Mês/Ano\n");
                }

            } while (!sucesso);

            //Seleciona o construtor referente ao tipo de conta especificado pelo usuário.
            switch (entradaTipoConta)
            {
                //Construtor da classe ContaPoupança com os parametros próprios da classe.
                case 1:

                    //Saldo Minimo e Validação da entrada de dados
                    do
                    {
                        Console.Write("Digite o saldo inicial da conta: ");
                        sucesso = double.TryParse(Console.ReadLine(), out entradaSaldoMinimo);

                        if (!sucesso)
                        {
                            Console.WriteLine("Por Favor, Digite apenas numeros\n");
                        }

                    } while (!sucesso);

                    ContaPoupanca novaContaPoupanca = new ContaPoupanca(tipoConta: (TipoConta)entradaTipoConta,
                                                                        numeroConta: entradaNumeroConta,
                                                                        saldo: entradaSaldo,
                                                                        nome: entradaNome,
                                                                        cpf: entradaCpf,
                                                                        dataNascimento: entradaDataNascimento,
                                                                        saldoMinimo: entradaSaldoMinimo);

                    listaContaSalario.Add(null); // se a conta criada nao é salario, adiciona nulo na lista de contas salarios
                    listaContas.Add(novaContaPoupanca);
                    Console.WriteLine("Criando conta...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Conta poupança criada.");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
                    Console.ReadKey();

                    break;

                //Construtor da classe ContaSalario com os parametros próprios da classe.
                case 2:

                    Console.Write("Digite o nome da empresa:");
                    string nomeEmpresa = Console.ReadLine();

                    int entradaCNPJ;
                    do
                    {
                        Console.Write("Digite o CNPJ:");
                        sucesso = int.TryParse(Console.ReadLine(), out entradaCNPJ);

                        if (!sucesso)
                        {
                            Console.WriteLine("Por Favor, Digite apenas numeros\n");
                        }

                    } while (!sucesso);

                    double entradaSalario;
                    do
                    {
                        Console.Write("Digite o salário:");
                        sucesso = double.TryParse(Console.ReadLine(), out entradaSalario);

                        if (!sucesso)
                        {
                            Console.WriteLine("Por Favor, Digite apenas numeros\n");
                            continue;
                        }

                        if (entradaSalario <= 0)
                        {
                            Console.WriteLine("Por Favor, insira um salario valido (minimo R$00,01)");
                        }

                    } while (entradaSalario <= 0);

                    ContaSalario novaContaSalario = new ContaSalario(tipoConta: (TipoConta)entradaTipoConta,
                                                                                  numeroConta: entradaNumeroConta,
                                                                                  saldo: entradaSaldo,
                                                                                  nome: entradaNome,
                                                                                  cpf: entradaCpf,
                                                                                  dataNascimento: entradaDataNascimento,
                                                                                  nomeEmpresa: nomeEmpresa,
                                                                                  cnpj: entradaCNPJ,
                                                                                  salario: entradaSalario);

                    //verifica se a propriedade CNPJ está zerada a fim de validar as informações do holerite no
                    //construtor da classe, caso inválido, o objeto não é salvo.
                    if (novaContaSalario.CNPJPagador == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Não foi possível criar a conta por divergência entre os dados fornecidos e o holerite\n" +
                        "Pressione qualquer tecla para continuar");
                        Console.ReadKey();
                        break;
                    }
                    listaContaSalario.Add(novaContaSalario);
                    listaContas.Add(novaContaSalario);
                    Console.WriteLine("Criando conta...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Conta salário criada.");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                    break;

                //Construtor da classe ContaInvestimento com os parametros próprios da classe.
                case 3:
                    ContaInvestimento novaContaInvestidor = new ContaInvestimento(tipoConta: (TipoConta)entradaTipoConta,
                                                                                  numeroConta: entradaNumeroConta,
                                                                                  saldo: entradaSaldo,
                                                                                  nome: entradaNome,
                                                                                  cpf: entradaCpf,
                                                                                  dataNascimento: entradaDataNascimento);

                    string perfilInvestidor = novaContaInvestidor.SimulaPerfilInvestidor();

                    Console.WriteLine($"Seu perfil de investidor é {perfilInvestidor}");

                    listaContaSalario.Add(null); // se a conta criada nao é salario, adiciona nulo na lista de contas salarios
                    listaContas.Add(novaContaInvestidor);
                    Console.WriteLine("Criando conta...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Conta salário criada.");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
                    Console.ReadKey();

                    break;
            }

        }
        catch
        {
            bug = true;
            CadastrarConta();
        }
    }

    public static void ListarContas()
    {
        if (listaContas.Count == 0)
        {
            Console.Clear();
            Console.WriteLine("Não há contas abertas");
            Thread.Sleep(3000);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Listar contas");
            Console.WriteLine();
        }

        if (listaContas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta encontrada.");
            Console.WriteLine();
            return;
        }

        //Percorre a lista de contas criadas exibindo o ID da conta (criado no momento que ela é adicionada na List), nome do titular, numero da conta e tipo da conta
        for (int i = 0; i < listaContas.Count; i++)
        {
            Conta conta = listaContas[i];
            Console.WriteLine($"ID da conta: #{i} - Titular: {conta.Nome} - Número da conta: {conta.NumeroConta} Tipo da Conta: {conta.TipoConta}");
        }
        Console.WriteLine();
        Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    //Esse método passamos o ID das contas que queremos tirar o dinheiro e o da conta que queremos enviar o dineiro, ele identifica esses IDs dentro da List de contas criadas, com isso ele chama o método TransferirDinheiro da classe Conta
    public static void Transferir()
    {
        int indiceContaDestino, indiceContaOrigem;
        double valorTransferencia;
        bool sucesso, bug = false;

        try
        {
            Console.Clear();

            //Caso algum Erro de Conversão Aconteça
            if (bug)
            {
                Console.WriteLine("Um Erro Inesperado Aconteceu, Por Favor Tente Novamente");
            }

            //ID da conta destino e Validação da entrada de dados     
            do
            {
                Console.Write("Digite o ID da conta de destino: ");
                sucesso = int.TryParse(Console.ReadLine(), out indiceContaDestino);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                }

            } while (!sucesso);

            //ID da conta de origem e Validação da entrada de dados
            do
            {
                Console.Write("Digite o ID da conta de origem: ");
                sucesso = int.TryParse(Console.ReadLine(), out indiceContaOrigem);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                }

            } while (!sucesso);

            //Valor a ser Transferido e Validação da entrada de dados
            do
            {
                Console.Write("Digite a quantia a ser transferida: ");
                sucesso = double.TryParse(Console.ReadLine(), out valorTransferencia);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                    continue;
                }

                if (valorTransferencia <= 0)
                {
                    Console.WriteLine("Por Favor, insira um valor valido para transferencia (minimo R$00,01)");
                }

            } while (valorTransferencia <= 0);

            listaContas[indiceContaOrigem].TransferirDinheiro(valorTransferencia, listaContas[indiceContaDestino]);

            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }
        catch
        {
            bug = true;
            Transferir();
        }
    }

    //Esse método passamos os IDs da conta que queremos Sacar e o valor a ser sacado, ele identifica esse ID dentro da List de contas criadas, com isso ele chama o método SacarDinheiro da classe Conta
    public static void Sacar()
    {
        int indiceConta;
        double valorSaque;
        double taxaSaque;
        bool sucesso, bug = false;

        try
        {
            Console.Clear();

            //Caso algum Erro de Conversão Aconteça
            if (bug)
            {
                Console.WriteLine("Um Erro Inesperado Aconteceu, Por Favor Tente Novamente");
            }

            //ID da conta e Validação da entrada de dados
            do
            {
                Console.Write("Digite o ID da conta: ");
                sucesso = int.TryParse(Console.ReadLine(), out indiceConta);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                }

            } while (!sucesso);

            do
            {
                Console.Write("Digite a quantia a ser sacada: ");
                sucesso = double.TryParse(Console.ReadLine(), out valorSaque);
                taxaSaque = listaContas[indiceConta].CalcularValorTarifaManutencao();

                    valorSaque -= taxaSaque;     
                    

                    if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                    continue;
                }

                if (valorSaque <= 0)
                {
                    Console.WriteLine("Por Favor, insira um valor valido para sacar (minimo R$00,01)");
                }

            } while (valorSaque <= 0);


            listaContas[indiceConta].SacarDinheiro(valorSaque);

            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }
        catch 
        {
            bug = true;
            Sacar();
        }
    }

    //Esse método passamos o ID da conta que queremos depositar e o valor a ser depositado, ele identifica esse ID dentro da List de contas criadas, com isso ele chama o método DepositarDinheiro da classe Conta
    public static void Depositar()
    {
        TipoConta tipoDeConta;
        int indiceConta, cnpj;
        double valorDeposito;
        bool sucesso, bug = false;

        try
        {
            Console.Clear();

            //Caso algum Erro de Conversão Aconteça
            if (bug)
            {
                Console.WriteLine("Um Erro Inesperado Aconteceu, Por Favor Tente Novamente");
            }

            //ID da conta e Validação da entrada de dados
            do
            {
                Console.Write("Digite o ID da conta: ");
                sucesso = int.TryParse(Console.ReadLine(), out indiceConta);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                }

            } while (!sucesso);

            //valida se o tipo de conta é salario para alterar o deposito para deposito de salario(conta salario só se pode depositar o salario)
            tipoDeConta = listaContas[indiceConta].TipoConta;
            if (tipoDeConta == TipoConta.ContaSalario)
            {
                Console.Clear();
                Console.WriteLine("Depósito em conta Salário selecionado");

                do
                {
                    Console.WriteLine("Digite o número do seu CNPJ (apenas números): ");
                    sucesso = int.TryParse(Console.ReadLine(), out cnpj);

                    if (!sucesso)
                    {
                        Console.WriteLine("Por Favor, digite apenas numeros\n");
                    }

                } while (!sucesso);

                //chama o metodo depositar salario na classe conta salario e passa os paramentros
                listaContaSalario[indiceConta].DepositarSalario(listaContaSalario[indiceConta].Salario, indiceConta, cnpj);
            }
            else 
            {
                do
                {
                    Console.Write("Digite a quantia a ser depositada: ");
                    sucesso = double.TryParse(Console.ReadLine(), out valorDeposito);

                    if (!sucesso)
                    {
                        Console.WriteLine("Por Favor, digite apenas numeros\n");
                        continue;
                    }

                    if (valorDeposito <= 0)
                    {
                        Console.WriteLine("Por Favor, insira um valor valido para depositar (minimo R$00,01)");
                    }

                } while (valorDeposito <= 0);

                listaContas[indiceConta].DepositarDinheiro(valorDeposito);
            }

            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }
        catch 
        {
            bug = true;
            Depositar();
        }
    }

    //Nesse método, a variavel indiceConta percorre a List listaContas em que estão armazenadas as contas, identificando a respectiva pelo Id que é gerado quando a conta é adicionada nessa List, então ela chama o método ExtratoBancário da classe Conta
    public static void VerExtrato()
    {
        int indiceConta;
        bool sucesso, bug = false;

        try
        {
            Console.Clear();

            //Caso algum Erro de Conversão Aconteça
            if (bug)
            {
                Console.WriteLine("Um Erro Inesperado Aconteceu, Por Favor Tente Novamente");
            }

            //ID da conta e Validação da entrada de dados
            do
            {
                Console.Write("Digite o ID da conta: ");
                sucesso = int.TryParse(Console.ReadLine(), out indiceConta);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                }

            } while (!sucesso);

            Console.WriteLine("------------Extrato------------");
            listaContas[indiceConta].ExtratoBancario();

            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }
        catch
        {
            bug = true;
            VerExtrato();
        }
    }

        //Gerador de número de conta automático
        public static double GerarNumeroConta()
        {
            Random rnd = new Random();
            double numeroContaRandom = rnd.Next(100000, 999999);

            return numeroContaRandom;
        }

            //Menu da aplicação
            public static string ObterOpcaoDoUsuario()
    {
        Console.WriteLine();
        Console.WriteLine("Bem vindo(a) ao Banco!!!");
        Console.WriteLine();
        Console.WriteLine("Digite a opção desejada: ");

        Console.WriteLine("1 - Cadastrar uma conta");
        Console.WriteLine("2 - Listar contas");
        Console.WriteLine("3 - Transferir");
        Console.WriteLine("4 - Sacar");
        Console.WriteLine("5 - Depositar");
        Console.WriteLine("6 - Ver extrato");
        Console.WriteLine("C - Limpar terminal");
        Console.WriteLine("E - Sair");
        Console.WriteLine();

        string opcoesEsperadas = "123456CE";
        string opcaoDoUsuario;

        //Validação da opção do usuario
        do
        {
            opcaoDoUsuario = Console.ReadLine().ToUpper();

            if (!opcoesEsperadas.Contains(opcaoDoUsuario))
            {
                Console.WriteLine("Opção digitada não existe, por favor digite uma das opções acima\n");
            }
        } while (!opcoesEsperadas.Contains(opcaoDoUsuario));

        Console.WriteLine();
        return opcaoDoUsuario;
    }

}
}
