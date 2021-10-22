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
    public partial class frmPrincipal : Form
    {
        public struct Usuario
        {
            public int codigo;
            public string nome;
            public string nivel;
            public string login;
            public string senha;
        }
        public struct Cliente
        {
            public int codigo;
            public string nome;
            public int telefone;
            public string email;
            public int cpf;
        }
        //array vetor declarado

        static public Usuario[] usuarios = new Usuario[10];
        static public int cadusu = 0;

        //cadastrando cliente

        static public Cliente[] clientes = new Cliente[10];
        static public int cadcli = 0;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario fu = new frmUsuario();
            fu.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente fc = new frmCliente();
            fc.ShowDialog();
        }

        private void pdpCliente_Load(object sender, EventArgs e)
        {

        }

        private void pdRelUsuario_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 0;
            string strDados;
            Graphics objImpresso = e.Graphics;

            strDados = "Relatório de Usuários" + (char)10 + (char)10;
            strDados += "Código Nome                                        Nível  Login" + (char)10;
            strDados += "---------------------------------------------------------------" + (char)10;
            while (x < cadusu)
            {
                strDados += usuarios[x].codigo.ToString("000000")+" "+usuarios[x].nome.PadRight(40)+ "   "+
                    usuarios[x].nivel+"   "+usuarios[x].login + (char)10;
                x++;
            }
            // 6 de fonte é o mínimo.
            objImpresso.DrawString(strDados, new System.Drawing.Font("Courier New", 10, FontStyle.Regular),Brushes.Black, 50, 50);
        }

        private void usuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pdpUsuario.ShowDialog();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pdpCliente.ShowDialog();
        }

        private void pdRelCliente_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 0;
            string strDados;
            Graphics objImpresso = e.Graphics;

            strDados = "Relatório de Clientes" + (char)10 + (char)10;
            strDados += "Código Nome                                      Telefone  Email                           CPF                  " + (char)10;
            strDados += "--------------------------------------------------------------------------------------------------------" + (char)10;
            while (x < cadcli)
            {
                strDados += clientes[x].codigo.ToString("000000") + " " + clientes[x].nome.PadRight(40) + "  " +
                    clientes[x].telefone + " " + clientes[x].email +"    " + clientes[x].cpf + (char)10;
                x++;
            }
            // 6 de fonte é o mínimo.
            objImpresso.DrawString(strDados, new System.Drawing.Font("Courier New", 8, FontStyle.Regular), Brushes.Black, 50, 50);
        }
    }
}
