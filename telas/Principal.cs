using SumulaFacil.basicas;
using SumulaFacil.telas.telasInternas;
using System;

using System.Windows.Forms;

namespace SumulaFacil.telas 
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

       

    

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("As alterações não salvas serão descartadas!", "Tem certeza que deseja sair ?"
                           , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
           
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("As alterações não salvas serão descartadas!", "Tem certeza que deseja sair ?"
                          , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }


        private void Principal_Load(object sender, EventArgs e)
        {
           toolStripStatusLabel1.Text = Perfil.usuarioLogado;
        }

        private void anotadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "CadastrarJogador")
                {
                    i = -1;
                    break;
                }
            }

            if (i != -1)
            {
                CadastrarAnotador cadastrar = new CadastrarAnotador();

                cadastrar.MdiParent = this;
                cadastrar.Show();
            }

        }
    }
}
