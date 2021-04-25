using SumulaFacil.basicas;
using SumulaFacil.controladores;
using SumulaFacil.dao;
using SumulaFacil.Icontroladores;
using SumulaFacil.idao;
using SumulaFacil.util;
using System;
using System.Windows.Forms;

namespace SumulaFacil.telas
{
    public partial class Login : Form
    {
        
        public Login()
          
        {
           
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            IusuarioControlador iControlador = new UsuarioControlador();
            IdaoUsuario idao = new DaoUsuario();

            if ((iControlador.loginControlador(textBox1.Text, textBox2.Text, comboBox1.SelectedIndex)) == true)
            {
                if (idao.login(new Usuario(textBox1.Text, textBox2.Text, comboBox1.SelectedIndex)) == true)
                {
                    Hide();
                    Perfil.usuarioLogado = textBox1.Text;

                    Principal principal = new Principal();
                    principal.Show();
                    limpar();
                    
                }
                else
                {
                    limpar();
                    MessageBox.Show("'Usuário', 'Senha' e/ou 'Nível de acesso' inválidos!");
                }
            }
            else {
                limpar();
                 }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpar();
        }

    

        public void limpar() {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = -1;

        }

      

      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            TelaUsuarioDirigente usuarioDirigente = new TelaUsuarioDirigente();
            usuarioDirigente.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        
            if (Util.verificaStatusConexao()) 
            {
                pictureBox2.Image = Properties.Resources.simbolo_de_verificacao_de_banco_de_dados;
            }
           
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
