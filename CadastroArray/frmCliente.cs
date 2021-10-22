using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroArray
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }
        bool tipo;
        int atual;
        private void Habilita()
        {

            txtCodigo.Enabled = false;
            txtNome.Enabled = true;
            txtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            txtCPF.Enabled = true;
            btnSalvar.Enabled = true;
            btnCancelar.Enabled = true;
            btnAnterior.Enabled = false;
            btnProximo.Enabled = false;
            btnNovo.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnPesquisar.Enabled = false;
            btnImprimir.Enabled = false;
            btnSair.Enabled = false;
        }
        private void Desabilita()
        {

            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtCPF.Enabled = false;
            btnSalvar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAnterior.Enabled = true;
            btnProximo.Enabled = true;
            btnNovo.Enabled = true;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnPesquisar.Enabled = true;
            btnImprimir.Enabled = true;
            btnSair.Enabled = true;
            pnlPesquisa.Visible = false;
        }
        private void Mostra()
        {
            txtCodigo.Text = frmPrincipal.clientes[atual].codigo.ToString();
            txtNome.Text = frmPrincipal.clientes[atual].nome;
            txtTelefone.Text = frmPrincipal.clientes[atual].telefone.ToString();
            txtEmail.Text = frmPrincipal.clientes[atual].email;
            txtCPF.Text = frmPrincipal.clientes[atual].cpf.ToString();
        }


        private void frmCliente_Load(object sender, EventArgs e)
        {
            Desabilita();
            atual = 0;
            Mostra();

        }
        

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (frmPrincipal.cadcli < 10)
            {
                Habilita();
                txtCodigo.Text = (frmPrincipal.cadcli + 1).ToString();
                txtNome.Text = "";
                txtTelefone.Clear();
                txtEmail.Clear();
                txtCPF.Clear();
                tipo = true;
            }
            else
            {
                //como temos 10 espaços no método, a partir do 11, os dados não serão salvos/cadastrados.
                MessageBox.Show("Impossível realizar novos cadastros!");
            }
        }
        //texto aqui

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            Desabilita();
            if (tipo)
            {
                frmPrincipal.clientes[frmPrincipal.cadcli].codigo = int.Parse(txtCodigo.Text);
                frmPrincipal.clientes[frmPrincipal.cadcli].nome = txtNome.Text;
                frmPrincipal.clientes[frmPrincipal.cadcli].telefone = int.Parse(txtTelefone.Text);
                frmPrincipal.clientes[frmPrincipal.cadcli].email = txtEmail.Text;
                frmPrincipal.clientes[frmPrincipal.cadcli].cpf = int.Parse(txtCPF.Text);
                atual = frmPrincipal.cadcli++;
            }
            else
            {
                frmPrincipal.clientes[atual].nome = txtNome.Text;
                frmPrincipal.clientes[atual].telefone = int.Parse(txtTelefone.Text);
                frmPrincipal.clientes[atual].email = txtEmail.Text;
                frmPrincipal.clientes[atual].cpf = int.Parse(txtCPF.Text);
            }
        }

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            Habilita();
            tipo = false;
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            Desabilita();
        }

        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            if (atual > 0)
            {
                atual--;
                Mostra();
            }
        }

        private void btnProximo_Click_1(object sender, EventArgs e)
        {
            if (atual < frmPrincipal.cadusu - 1)
            {
                atual++;
                Mostra();
            }
        }
        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a exclusão do cadastro?", "Confirmação",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmPrincipal.clientes[atual].nome = "";
                frmPrincipal.clientes[atual].telefone = 0;
                frmPrincipal.clientes[atual].email = "";
                frmPrincipal.clientes[atual].cpf = 0;
                Mostra();
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void btnCancelarPesquisa_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            pnlPesquisa.Visible = true;
            txtPesquisa.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int x;
            if (txtPesquisa.Text != "")
            {
                for (x = 0; x < 10; x++)
                {
                    if (frmPrincipal.clientes[x].nome == txtPesquisa.Text)
                    {
                        atual = x;
                        Mostra();
                        break;
                    }
                }
                if (x == 10)
                {
                    MessageBox.Show("Nome não encontrado!");
                }
                pnlPesquisa.Visible = false;
                txtPesquisa.Text = "";
            }

            else
            {
                MessageBox.Show("Digite um nome para pesquisa!");
                txtPesquisa.Focus();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string strDados;
            Graphics objImpressao = e.Graphics;
            strDados = "FICHA DE CLIENTE" + (char)10 + (char)10;
            strDados = strDados + "Código: " + txtCodigo.Text + (char)10 + (char)10;
            strDados = strDados + "Nome: " + txtNome.Text + (char)10 + (char)10;
            strDados = strDados + "Telefone: " + txtTelefone.Text + (char)10 + (char)10;
            strDados = strDados + "Email: " + txtEmail.Text;
            objImpressao.DrawString(strDados, new System.Drawing.Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 50);
            objImpressao.DrawLine(new System.Drawing.Pen(Brushes.Black, 1), 50, 80, 780, 80);
        }

        private void pnlPesquisa_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
