using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Mercado_de_Acoes
{
    public string NomeEmpresa { get; set; }
    public double ValorPapeisDisponiveis { get; set; }
    public long CNPJ { get; set; }

    

    public Mercado_de_Acoes(string nome, double valorPapeis, long atribuirCnpj)
    {
        this.NomeEmpresa = nome;
        this.CNPJ = atribuirCnpj;

        if(this.ValorPapeisDisponiveis == 0)
        {
            this.ValorPapeisDisponiveis = valorPapeis;
        }

    }

    //Criação objetos da classe mercado de ações.
    // Mercado_de_Acoes empresa1 = new Mercado_de_Acoes("Industrias ACME", 1000000, 12345678912345);
    // Mercado_de_Acoes empresa2 = new Mercado_de_Acoes("Loja de pão", 200000, 98765432198765);
    // Mercado_de_Acoes empresa3 = new Mercado_de_Acoes("Mamaco Corp", 500000, 91764823579468);

}


