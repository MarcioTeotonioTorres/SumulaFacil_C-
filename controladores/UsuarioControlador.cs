using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Owin;
using SumulaFacil.basicas;
using SumulaFacil.dao;
using SumulaFacil.Icontroladores;
using SumulaFacil.idao;

[assembly: OwinStartup(typeof(SumulaFacil.controladores.UsuarioControlador))]

namespace SumulaFacil.controladores
{
    public class UsuarioControlador : IusuarioControlador
    {

        public UsuarioControlador(){}


        public Boolean loginControlador(string usuario, string senha, int perfil)
        {

            if ((usuario.Trim() == "") || (senha.Trim() == "") || (perfil < 0) || (perfil > 1))
            {
                MessageBox.Show("Os campos 'Nome de usuario','Senha' e/ou 'Nível de acesso' são obrigatórios!");
                return false;
            }

                     

            else

            {
                return true;
            }


        }


        public Usuario controladorNovoDirigente(string nome, string cpf, string idade, string telefone, string cep,
            string numeroResidencial, string nomeUsuario, string senha, string confirmaSenha)
        {
                IdaoUsuario idao = new DaoUsuario();
                Usuario u = new Usuario();

            if ((string.IsNullOrEmpty(nome.Trim())) || (string.IsNullOrEmpty(cpf.Trim())) || (string.IsNullOrEmpty(idade.Trim()))
                || (string.IsNullOrEmpty(telefone.Trim())) || (string.IsNullOrEmpty(cep.Trim())) || (string.IsNullOrEmpty(numeroResidencial.Trim()))
                || (string.IsNullOrEmpty(nomeUsuario.Trim())) || (string.IsNullOrEmpty(senha.Trim())) || (string.IsNullOrEmpty(confirmaSenha.Trim())))

            {
                MessageBox.Show("Todos os campos são obrigatórios!");
                throw new ArgumentException("Todos os campos são obrigatórios!");
            }
            else if ((cpf.Trim() == "000.000.000-00") || (cpf.Trim() == "111.111.111-11")
                || (cpf.Trim() == "222.222.222-22") || (cpf.Trim() == "333.333.333-33")
                || (cpf.Trim() == "444.444.444-44") || (cpf.Trim() == "555.555.555-55")
                || (cpf.Trim() == "666.666.666-66") || (cpf.Trim() == "777.777.777-77")
                || (cpf.Trim() == "888.888.888-88") || (cpf.Trim() == "999.999.999-99"))
            {
                MessageBox.Show("Cpf inválido!");
                throw new ArgumentException("Cpf inválido!");
            }
            else if ((telefone == "(00)00000-0000") || (telefone == "(11)11111-1111") || (telefone == "(22)22222-2222")
               || (telefone == "(33)33333-3333") || (telefone == "(44)44444-4444") || (telefone == "(55)55555-5555")
               || (telefone == "(66)66666-6666") || (telefone == "(77)77777-7777") || (telefone == "(88)88888-8888")
               || (telefone == "(99)99999-9999"))
            {
                MessageBox.Show("Telefone inválido!");
                throw new ArgumentException("Telefone inválido!");
            }
            else if ((cep == "00000-000") || (cep == "11111-111") || (cep == "22222-222") || (cep == "33333-333")
                || (cep == "44444-444") || (cep == "55555-555") || (cep == "66666-666") || (cep == "77777-777") || (cep == "88888-888")
                || (cep == "99999-999"))
            {
                MessageBox.Show("Cep inválido!");
                throw new ArgumentException("Cep inválido!");
            }
            else if (!senha.Equals(confirmaSenha))
            {
                MessageBox.Show("As senhas não conferem!");
                throw new ArgumentException("As senhas não conferem!");
            }
           
            else if (idao.consultaCpfCadastrado(cpf) == true)
            {
                MessageBox.Show("Este 'CPF' ja está cadastrado!");
                throw new ConstraintException("Este 'CPF' ja está cadastrado!!");
            }
            else if (idao.consultaNomeCadastrado(nome) == true)
            {
                MessageBox.Show("Este 'Dirigente' já está cadastrado!");
                throw new ConstraintException("Este 'Dirigente' já está cadastrado!");
            }
            else if (idao.consultaNomeUsuarioCadastrado(nomeUsuario) == true)
            {
                MessageBox.Show("Este 'Nome de usuario' já está cadastrado!");
                throw new ConstraintException("Este 'Nome de usuario' já está cadastrado!");
            }
            else if (idao.consultaSenhaCadastrada(senha) == true)
            {
                MessageBox.Show("Esta 'Senha' já está cadastrada!");
                throw new ConstraintException("Esta 'Senha' já está cadastrada! ");
            }
            else
            {

                u.Nome = nome.Trim();
                u.Cpf = cpf.Trim().Replace(",", ".");
                u.Idade = idade.Trim();
                u.Telefone = telefone.Trim();
                u.Cep = cep.Trim();
                u.NumeroResidencial = numeroResidencial.Trim();
                u.NomeUsuario = nomeUsuario.Trim();
                u.Senha = senha.Trim();
                u.PerfilUsuario = (int)Perfil.NivelAcesso.Dirigente;

                return u;
            } 
               
            
           
        }

    }
      
}
