
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumulaFacil.connenction
{



    public static class Conexao
    {


        private static readonly string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Marcio Torres\source\repos\SumulaFacil\sumulaBd.mdf;Integrated Security=True;Connect Timeout=30";
        private static SqlConnection sqlConnection;

        public static SqlConnection GetConnection()
        {

            try
            {
                if (sqlConnection == null)
                {
                    sqlConnection = new SqlConnection(con);
                    Console.WriteLine("Ta aqui chegou");
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("Errou ao criar conexao");
                Console.WriteLine(e.Message);

            }

            return sqlConnection;
        }

    }
}