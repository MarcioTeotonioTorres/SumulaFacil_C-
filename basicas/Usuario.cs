using SumulaFacil.basicas;
using System;


namespace SumulaFacil.dao
{
    public partial class Usuario : Pessoa, ICloneable
    { 

      

        private int idUsuario;
        private string nomeUsuario;
        private string senha;
        private string confirmaSenha;
        private int perfilUsuario;

        public Usuario() { }

        public Usuario(Usuario u)
        {
        }

        public Usuario(string nomeUsuario, string senha, int perfilUsuario)
        {
            
            this.nomeUsuario = nomeUsuario;
            this.senha = senha;
            this.perfilUsuario = perfilUsuario;
        }

        public Usuario(string nome, string cpf, string idade, string telefone, string cep, string numeroResidencial,
             string nomeUsuario, string senha, string confirmaSenha) : base()
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Telefone = telefone;
            Cep = cep;
            NumeroResidencial = numeroResidencial;           
            this.nomeUsuario = nomeUsuario;
            this.senha = senha;
            this.confirmaSenha = confirmaSenha;
        }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }
        public string Senha { get => senha; set => senha = value; }
        public int PerfilUsuario { get => perfilUsuario; set => perfilUsuario = value; }

        public object Clone()
        {
            return new Usuario(this);
        }
    }
}