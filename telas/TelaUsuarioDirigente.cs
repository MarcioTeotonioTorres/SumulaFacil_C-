using SumulaFacil.controladores;
using SumulaFacil.dao;
using SumulaFacil.Icontroladores;
using SumulaFacil.idao;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SumulaFacil.telas
{
    public partial class TelaUsuarioDirigente : Form
    {
        public TelaUsuarioDirigente()
        {
            InitializeComponent();
        }

        private void TelaUsuarioDirigente_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                if (MessageBox.Show("As alterações não salvas serão descartadas!", "Tem certeza que deseja sair ?"
                           , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   
                    Login l = new Login();
                    l.Show();
                }
                else
                {
                    e.Cancel = true;
                }         

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Hide();
            Login login = new Login();
            login.Show();

        }  

        private void button3_Click(object sender, EventArgs e)
        {
            limpar();
        }

        private void limpar() {
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            comboBox1.SelectedIndex = -1;
            
        }

        private void desabilitarCampos() 
        {
            textBox2.Enabled = false;
            maskedTextBox1.Enabled = false;
            maskedTextBox2.Enabled = false;
            maskedTextBox3.Enabled = false;
            comboBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            textBox6.Enabled = false;
            comboBox1.SelectedIndex = -1;
            button1.Enabled = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IdaoUsuario idao = new DaoUsuario();
            IusuarioControlador iUserControlador = new UsuarioControlador();

            try
            {
                if (idao.inserirUsuarioDirigente(iUserControlador.controladorNovoDirigente(textBox2.Text,
                    maskedTextBox1.Text, comboBox1.Text, maskedTextBox3.Text, maskedTextBox2.Text, textBox3.Text, textBox4.Text, 
                    textBox5.Text, textBox6.Text)) == true)
                {

                    
                    button5.Enabled = true;
                    button3.Enabled = false;
                    label14.Text = "Bem vindo! "+textBox4.Text;
                    MessageBox.Show("Cadastrado com sucesso!");
                    desabilitarCampos();

                }
                else 
                {
                    MessageBox.Show("Erro no controle do cadastro!"); 
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "\n" + ex.Source);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                IdaoUsuario idao = new DaoUsuario();
                Usuario u = idao.carregaUsuarioNaTabela(textBox4.Text);
                if (u.Equals(null))
                {
                    button5.Enabled = false;
                }
                else 
                {
                    dataGridView2.Rows.Add(u.IdUsuario, u.NomeUsuario, u.Senha, u.PerfilUsuario);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void TelaUsuarioDirigente_Load(object sender, EventArgs e)
        {

        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            desabilitarCampos(); 
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
