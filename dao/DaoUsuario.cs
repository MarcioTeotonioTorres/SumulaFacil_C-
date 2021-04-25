using SumulaFacil.connenction;
using SumulaFacil.idao;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SumulaFacil.dao
{
    public class DaoUsuario : IdaoUsuario
    {

        private SqlConnection con;
       
        public DaoUsuario()
        {          

        }


        public Boolean login(Usuario u)
        {
           
            try {
  
                String sql = "select nomeUsuario,senha,perfilUsuario from usuario where " +
                    "nomeUsuario = @nomeUsuario and senha = @senha and perfilUsuario = @perfilUsuario; ";

                con = Conexao.GetConnection();
                con.Open();

                SqlCommand sqlCommand = new SqlCommand(sql, con);
                
                sqlCommand.Parameters.AddWithValue("@nomeUsuario", u.NomeUsuario);
                sqlCommand.Parameters.AddWithValue("@senha", u.Senha);
                sqlCommand.Parameters.AddWithValue("@perfilUsuario", u.PerfilUsuario);
                
                SqlDataReader reader = sqlCommand.ExecuteReader();
                
                if (reader.Read())
                {
                    Console.WriteLine("Logado!");
                    reader.Close();
                    return true;
                    
                }
                else
                {
                    Console.WriteLine("Usuario inválido!");
                    reader.Close();
                    return false;
                }
                
            } catch(Exception e) {
                Console.WriteLine(e.Message);
             
                return false;
            } finally {
                
                con.Close();
                
            }

            
        }
        public Boolean inserirUsuarioDirigente(Usuario u)
        {   
           
                con = Conexao.GetConnection();            
                con.Open();
           
                SqlTransaction sqlt = con.BeginTransaction();

            try
            { 

                string sql = "insert into pessoa(nome,idade,cpf,telefone,cep,numeroResidencial) values (@nome,@idade,@cpf,@telefone,@cep,@numeroResidencial); " +
                                "insert into usuario(idUsuario, nomeUsuario, senha, perfilUsuario) values((select max(matricula) from pessoa),@nomeUsuario,@senha,@perfilUsuario); ";

                SqlCommand cmdPessoa = new SqlCommand(sql, con)
                {
                    Transaction = sqlt
                };
                cmdPessoa.Parameters.AddWithValue("@nome", u.Nome);
                cmdPessoa.Parameters.AddWithValue("@idade", u.Idade);
                cmdPessoa.Parameters.AddWithValue("@cpf", u.Cpf);
                cmdPessoa.Parameters.AddWithValue("@telefone", u.Telefone);
                cmdPessoa.Parameters.AddWithValue("@cep", u.Cep);
                cmdPessoa.Parameters.AddWithValue("@numeroResidencial", u.NumeroResidencial);
                cmdPessoa.Parameters.AddWithValue("@nomeUsuario", u.NomeUsuario);
                cmdPessoa.Parameters.AddWithValue("@senha", u.Senha);
                cmdPessoa.Parameters.AddWithValue("@perfilUsuario", u.PerfilUsuario);
                cmdPessoa.ExecuteNonQuery();
                sqlt.Commit();
                return true;


            }
            catch (SqlException e)
            {
                Console.WriteLine("Erro na dao em pessoa");
                Console.WriteLine("duplicado" + e.Message);
                Console.WriteLine(e.Message.EndsWith(u.Nome));
                Console.WriteLine("duplicado 1 " + e.Data);
                Console.WriteLine("duplicado 2 " + e.Errors);
                Console.WriteLine("duplicado 3 " + e.State);
                Console.WriteLine("duplicado 4 " + e.Number);
                sqlt.Rollback();
                con.Close();
                return false;
            }
            
            finally
            {

                con.Close();

            }

        }

        public bool apagar(Usuario u)
        {
            throw new NotImplementedException();
        }
        public int consultaIdPorNome(String nome)
        {

            try
            {
                con = Conexao.GetConnection();
                con.Open();
                String verId = "select matricula from pessoa where pessoa.nome = @nome";

                SqlCommand cmd = new SqlCommand(verId, con);
                cmd.Parameters.AddWithValue("@nome", nome);

                SqlDataReader reader = cmd.ExecuteReader(); ;



                if (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    reader.Close();
                    con.Close();
                    return id;

                }
                else
                {
                    return 0;
                }

            }


            catch (SqlException e)
            {
                con.Close();
                MessageBox.Show("Erro aqui no id");
                Console.WriteLine(e.Message);
                return 0;

            }
            finally
            {

                con.Close();
            }
           
        }

        
        public bool consultaNomeCadastrado(string nome)
        {
            try
            {
                con = Conexao.GetConnection();
                con.Open();
                SqlDataReader reader;
                String query = "select nome from pessoa where nome = @nome";


                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@nome", nome);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    return false;
                }

            }


            catch (SqlException e)
            {
                MessageBox.Show("Erro aqui no id");
                Console.WriteLine(e.Message);
                con.Close();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool consultaCpfCadastrado(string cpf)
        {
            try
            {
                con = Conexao.GetConnection();
                con.Open();
                SqlDataReader reader;
                String query = "select cpf from pessoa where cpf = @cpf";


                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@cpf", cpf);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    con.Close();
                    return false;
                }

            }


            catch (SqlException e)
            {
                MessageBox.Show("Erro aqui no cpf");
                Console.WriteLine(e.Message);
                return false;
            }
            finally 
            {
                con.Close();
            }
        }

        public bool consultaNomeUsuarioCadastrado(string nomeUsuario)
        {
            try
            {
                con = Conexao.GetConnection();
                con.Open();

                String query = "select nomeUsuario from usuario where nomeUsuario = @nomeUsuario";


                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {

                    return true;
                }
                else
                {
                    return false;
                }

            }


            catch (SqlException e)
            {
                MessageBox.Show("Erro aqui no id");
                Console.WriteLine(e.Message);
                return false;
            }
            finally 
            {
                con.Close();
            }
        }

        public bool consultaSenhaCadastrada(string senha)
        {
            try
            {
                con = Conexao.GetConnection();
                con.Open();

                SqlDataReader reader;
                String query = "select senha from usuario where senha = @senha";


                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@senha", senha);

                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    reader.Close();
                    con.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    con.Close();
                    return false;
                }

            }


            catch (SqlException e)
            {
                MessageBox.Show("Erro aqui na senha");
                Console.WriteLine(e.Message);
                con.Close();
                return false;
            }
            finally 
            {
                con.Close();
            }
        }

        public Usuario carregaUsuarioNaTabela(string nomeUsuario)
        {
            con = Conexao.GetConnection();
            con.Open();
            try
            {

                String query = "select idUsuario,nomeUsuario,senha,perfilUsuario from usuario where nomeUsuario = @nomeUsuario";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);

                SqlDataReader reader;
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Usuario u = new Usuario();

                    u.IdUsuario = reader.GetInt32(0);
                    u.NomeUsuario = reader.GetString(1);
                    u.Senha = reader.GetString(2);
                    u.PerfilUsuario = reader.GetInt32(3);
                    reader.Close();
                    con.Close();
                    return u;
                }
                else
                {
                    reader.Close();
                    con.Close();
                    return null;
                }

            }


            catch (SqlException e)
            {

                con.Close();
                MessageBox.Show("Erro ao preecher tabela ");
                Console.WriteLine(e.Message);
                return null;
            }
            finally 
            {
                con.Close();
            }
        }
    }

}

