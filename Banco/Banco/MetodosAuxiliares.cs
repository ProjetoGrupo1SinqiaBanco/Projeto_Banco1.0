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
            double entradaSaldo = 0;
            string entradaNome;
            DateTime entradaDataNascimento;
            bool sucesso;

            Console.Clear();
            Console.WriteLine("CADASTRAR NOVA CONTA\n");

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

            //Nome do Titular
            do
            {
                Console.Write("Digite o nome do titular da conta: ");
                entradaNome = Console.ReadLine();

                sucesso = double.TryParse(entradaNome, out double eNumero);

                if (sucesso)
                {
                    Console.WriteLine("Por favor, digite um nome válido para a a criação da sua conta!\n");
                }

            } while (sucesso);

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

                    double entradaSaldoMinimo = 50;

                    //Saldo Minimo e Validação da entrada de dados
                    do
                    {
                        Console.WriteLine($"\nO saldo mínimo para a criação da conta poupança é R${entradaSaldoMinimo},00");
                        Console.Write("Escolha o valor do seu primeiro depósito: R$");
                        sucesso = double.TryParse(Console.ReadLine(), out entradaSaldo);

                        if (!sucesso)
                        {
                            Console.WriteLine("Por Favor, Digite apenas numeros\n");
                            continue;
                        }

                        if (entradaSaldo < entradaSaldoMinimo)
                        {
                            Console.WriteLine($"O saldo deve ser maior que R${entradaSaldoMinimo},00.\n");
                        }

                    } while (entradaSaldo < entradaSaldoMinimo);

                    ContaPoupanca novaContaPoupanca = new ContaPoupanca(tipoConta: (TipoConta)entradaTipoConta,
                                                                        numeroConta: entradaNumeroConta,
                                                                        saldo: entradaSaldo,
                                                                        nome: entradaNome,
                                                                        cpf: entradaCpf,
                                                                        dataNascimento: entradaDataNascimento,
                                                                        saldoMinimo: entradaSaldoMinimo);

                    listaContaSalario.Add(null); //se a conta criada nao é salario, adiciona nulo na lista de contas salarios
                    listaContas.Add(novaContaPoupanca);
                    Console.WriteLine("Criando conta...");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Conta poupança criada.");
                    Console.WriteLine($"O Número da Conta é: {entradaNumeroConta}\n");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                    break;

                //Construtor da classe ContaSalario com os parametros próprios da classe.
                case 2:

                    long entradaCNPJ;
                    double entradaSalario;
                    string nomeEmpresa;

                    //Nome da Empresa
                    Console.Write("Digite o nome da empresa: ");
                    nomeEmpresa = Console.ReadLine();

                    //CNPJ e Validação da entrada de dados
                    do
                    {
                        Console.Write("Digite o CNPJ: ");
                        sucesso = long.TryParse(Console.ReadLine(), out entradaCNPJ);

                        if (!sucesso)
                        {
                            Console.WriteLine("Por Favor, Digite apenas numeros\n");
                            continue;
                        }

                        if (entradaCNPJ.ToString().Length != 14)
                        {
                            Console.WriteLine("Por Favor, digite um CNPJ valido (14 digitos)\n");
                        }

                    } while (entradaCNPJ.ToString().Length != 14);

                    //Salario e Validação da entrada de dados
                    do
                    {
                        Console.Write("Digite o salário: ");
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
                    Console.WriteLine($"O Número da Conta é: {entradaNumeroConta}\n");
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
                    Console.WriteLine("Conta investimento criada.");
                    Console.WriteLine($"O Número da Conta é: {entradaNumeroConta}\n");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
                    Console.ReadKey();
                    break;
            }
        }

        public static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("LISTA DE CONTAS\n");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta encontrada.\n");
            }
            else
            {
                //Percorre a lista de contas criadas exibindo o nome do titular, numero da conta e tipo da conta
                for (int i = 0; i < listaContas.Count; i++)
                {
                    Conta conta = listaContas[i];
                    Console.WriteLine($"Titular: {conta.Nome} - Número da conta: {conta.NumeroConta} - Tipo da Conta: {conta.TipoConta}\n");
                }

            }

            Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }

        //Esse método passamos o numero da conta que queremos tirar o dinheiro e o da conta que queremos enviar o dinheiro, ele identifica as contas dentro da List de contas criadas, com isso ele chama o método TransferirDinheiro da classe Conta
        public static void Transferir()
        {
            int indiceContaDestino = -1, indiceContaOrigem = -1;
            double valorTransferencia;
            bool sucesso;

            Console.Clear();
            Console.WriteLine("TRANSFERÊNCIA\n");

            //Numero da conta destino e Validação da entrada de dados     
            do
            {
                Console.Write("Digite o numero da conta de destino: ");
                sucesso = int.TryParse(Console.ReadLine(), out int numeroContaDestino);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                    continue;
                }

                indiceContaDestino = ValidarNumeroConta(numeroContaDestino);

                if (indiceContaDestino < 0)
                {
                    Console.WriteLine("Por Favor, Digite uma conta valida para transferencia\n");
                }

            } while (indiceContaDestino < 0);

            //Numero da conta de origem e Validação da entrada de dados
            do
            {
                Console.Write("Digite o número da conta de origem: ");
                sucesso = int.TryParse(Console.ReadLine(), out int numeroContaOrigem);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                    continue;
                }

                indiceContaOrigem = ValidarNumeroConta(numeroContaOrigem);

                if (indiceContaOrigem < 0)
                {
                    Console.WriteLine("Por Favor, Digite uma conta valida para transferencia");
                }

            } while (indiceContaOrigem < 0);

            //Valor a ser Transferido e Validação da entrada de dados
            do
            {
                Console.Write("Digite a quantia a ser transferida: R$");
                sucesso = double.TryParse(Console.ReadLine(), out valorTransferencia);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                    continue;
                }

                if (valorTransferencia <= 0)
                {
                    Console.WriteLine("Por Favor, insira um valor válido para transferencia (minimo R$00,01)\n");
                }

            } while (valorTransferencia <= 0);

            listaContas[indiceContaOrigem].TransferirDinheiro(valorTransferencia, listaContas[indiceContaDestino]);

            Console.WriteLine("\nTransferência realizada com sucesso");
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }

        //Esse método passamos o Numero da conta que queremos Sacar e o valor a ser sacado, ele identifica a conta dentro da List de contas criadas, com isso ele chama o método SacarDinheiro da classe Conta
        public static void Sacar()
        {
            int indiceConta = -1;
            double valorSaque, taxaSaque;
            bool sucesso;

            Console.Clear();
            Console.WriteLine("SAQUES\n");

            //Numero da conta e Validação da entrada de dados
            do
            {
                Console.Write("Digite o numero da conta: ");
                sucesso = int.TryParse(Console.ReadLine(), out int numeroConta);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                    continue;
                }

                indiceConta = ValidarNumeroConta(numeroConta);

                if (indiceConta < 0)
                {
                    Console.WriteLine("Por Favor, Digite uma conta valida para sacar\n");
                }

            } while (indiceConta < 0);

            //Quantia a ser Sacada e Validação da entrada de dados
            do
            {
                Console.Write("Digite a quantia a ser sacada: R$");
                sucesso = double.TryParse(Console.ReadLine(), out valorSaque);
                taxaSaque = listaContas[indiceConta].CalcularValorTarifaManutencao(listaContas[indiceConta].TipoConta);

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

        //Esse método passamos o numero da conta que queremos depositar e o valor a ser depositado, ele identifica a conta dentro da List de contas criadas, com isso ele chama o método DepositarDinheiro da classe Conta
        public static void Depositar()
        {
            TipoConta tipoDeConta;
            int indiceConta = -1;
            long cnpj;
            double valorDeposito;
            bool sucesso;

            Console.Clear();
            Console.WriteLine("DEPOSITOS\n");

            //Numero da conta e Validação da entrada de dados
            do
            {
                Console.Write("Digite o numero da conta: ");
                sucesso = int.TryParse(Console.ReadLine(), out int numeroConta);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                    continue;
                }

                indiceConta = ValidarNumeroConta(numeroConta);

                if (indiceConta < 0)
                {
                    Console.WriteLine("Por Favor, Digite uma conta valida para depositar\n");
                }

            } while (indiceConta < 0);

            //valida se o tipo de conta é salario para alterar o deposito para deposito de salario(conta salario só se pode depositar o salario)
            tipoDeConta = listaContas[indiceConta].TipoConta;
            if (tipoDeConta == TipoConta.ContaSalario)
            {
                Console.Clear();
                Console.WriteLine("Depósito em conta Salário selecionado");

                //CNPJ e Validação da entrada de dados
                do
                {
                    Console.WriteLine("Digite o número do seu CNPJ (apenas números): ");
                    sucesso = long.TryParse(Console.ReadLine(), out cnpj);

                    if (!sucesso)
                    {
                        Console.WriteLine("Por Favor, Digite apenas numeros\n");
                        continue;
                    }

                    if (cnpj.ToString().Length != 14)
                    {
                        Console.WriteLine("Por Favor, digite um CNPJ valido (14 digitos)\n");
                    }

                } while (cnpj.ToString().Length != 14);

                //chama o metodo depositar salario na classe conta salario e passa os paramentros
                listaContaSalario[indiceConta].DepositarSalario(listaContaSalario[indiceConta].Salario, indiceConta, cnpj);
            }
            else
            {
                //Quantia a ser depositada e Validação da entrada de dados
                do
                {
                    Console.Write("Digite a quantia a ser depositada: R$");
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

            Console.WriteLine("\nAperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }

        //Nesse método, a variavel indiceConta percorre a List listaContas em que estão armazenadas as contas, identificando a respectiva pelo Id que é gerado quando a conta é adicionada nessa List, então ela chama o método ExtratoBancário da classe Conta
        public static void VerExtrato()
        {
            int indiceConta = -1;
            bool sucesso;

            Console.Clear();
            Console.WriteLine("EXTRATOS\n");

            //Numero da conta e Validação da entrada de dados
            do
            {
                Console.Write("Digite o numero da conta: ");
                sucesso = int.TryParse(Console.ReadLine(), out int numeroConta);

                if (!sucesso)
                {
                    Console.WriteLine("Por Favor, digite apenas numeros\n");
                }

                indiceConta = ValidarNumeroConta(numeroConta);

                if (indiceConta < 0)
                {
                    Console.WriteLine("Por Favor, Digite uma conta valida para ver o extrato\n");
                }

            } while (indiceConta < 0);

            Console.WriteLine("------------Extrato------------");
            listaContas[indiceConta].ExtratoBancario();

            Console.WriteLine();
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu");
            Console.ReadKey();
        }

        //Gerador de número de conta automático
        public static double GerarNumeroConta()
        {
            Random rnd = new Random();
            double numeroContaRandom = rnd.Next(100000, 999999);

            return numeroContaRandom;
        }

        //Compara o Numero da Conta inserida pelo usuario e as Contas ja existentes no sistema
        public static int ValidarNumeroConta(int numeroContaInformado)
        {
            int indiceConta = -1;

            //Percorre a lista de contas criadas comparando os numeros das mesmas com o numero da conta informado pelo usuario
            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];

                if (numeroContaInformado == conta.NumeroConta)
                {
                    indiceConta = i;
                    break;
                }
            }

            return indiceConta;
        }

        //Menu da aplicação
        public static string ObterOpcaoDoUsuario()
        {
            Console.WriteLine("\nBem vindo(a) ao Banco!!!\n");
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
