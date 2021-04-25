using Microsoft.Owin;
using SumulaFacil.connenction;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

[assembly: OwinStartup(typeof(SumulaFacil.util.Util))]

namespace SumulaFacil.util
{
    public static class Util 
    {
        private static SqlConnection con;

      public static bool verificaStatusConexao()
        {
            try
            {
                con = Conexao.GetConnection();
                con.Open();
                con.State.Equals(ConnectionState.Open);
                return true;
               

            }

            catch (SqlException ex)
            {
                MessageBox.Show("Erro na base de dados do programa\n" +" Suporte - relojoeiroart@hotmail.com", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.Message);
                Application.Exit();
                return false;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
