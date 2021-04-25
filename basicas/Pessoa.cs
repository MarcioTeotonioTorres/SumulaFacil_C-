using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumulaFacil.basicas
{
    public abstract class Pessoa
    {
       

        private int matricula;
        private String nome;
        private String idade;
        private String cpf;
        private String telefone;
        private String cep;
        private String numeroResidencial;
      

        public Pessoa()
        {
        }


        protected Pessoa(int matricula, string nome, string idade, string cpf,string telefone, string cep, string numeroResidencial)
        {
           
            this.matricula = matricula;
            this.nome = nome;
            this.idade = idade;
            this.cpf = cpf;
            this.telefone = telefone;
            this.cep = cep;
            this.numeroResidencial = numeroResidencial;
        }

        public int Matricula { get => matricula; set => matricula = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Idade { get => idade; set => idade = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Cep { get => cep; set => cep = value; }
        public string NumeroResidencial { get => numeroResidencial; set => numeroResidencial = value; }
    }
}
