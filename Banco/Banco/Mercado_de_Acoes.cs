using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Mercado_de_Acoes
{
    public string NomeEmpresa { get; set; }
    public double ValorPapeisDisponiveis { get; set; }
    public long CNPJ { get; set; }

    List<Mercado_de_Acoes> listaEmpresasNoMercado = new List<Mercado_de_Acoes>();

    public Mercado_de_Acoes(string nome, double valorPapeis, long atribuirCnpj)
    {
        this.NomeEmpresa = nome;
        this.ValorPapeisDisponiveis = valorPapeis;
        this.CNPJ = atribuirCnpj;

    }


    //Criação objetos da classe mercado de ações. Jogar no main posteriormente e em list
    Mercado_de_Acoes empresa1 = new Mercado_de_Acoes("Industrias ACME",1000000,12345678912345);
    Mercado_de_Acoes empresa2 = new Mercado_de_Acoes("Loja de pão",100000,98765432198765);
    Mercado_de_Acoes empresa3 = new Mercado_de_Acoes("Jaleco Corp",500000,91764823579468);
}


