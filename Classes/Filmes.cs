using System;
namespace AppSerie
{
    public class Filmes : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private string Elenco { get; set; }
        private string Direcao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        public Filmes(int id, Genero genero, string titulo, string descricao, string elenco, string direcao, int ano)
    {
        this.Id = id;
        this.Genero = genero;
        this.Titulo = titulo;
        this.Descricao = descricao;
        this.Elenco = elenco;
        this.Direcao = direcao;
        this.Ano = ano;
        this.Excluido = false;
    }
    public override string ToString()
    {
        string retorno = "";
        retorno += "Gênero: " + this.Genero + Environment.NewLine;
        retorno += "Título: " + this.Titulo + Environment.NewLine;
        retorno += "Descrição: " + this.Descricao + Environment.NewLine;
        retorno += "Elenco : " + this.Elenco + Environment.NewLine;
        retorno += "Direção: " + this.Direcao + Environment.NewLine;
        retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
        retorno += "Excluido: " + this.Excluido;
        return retorno;
    }
    public string retornaTitulo()
    {
        return this.Titulo;
    }
    public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
    }   
}