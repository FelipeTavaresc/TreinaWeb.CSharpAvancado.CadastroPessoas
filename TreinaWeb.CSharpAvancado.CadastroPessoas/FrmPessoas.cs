using CadastroPessoas.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreinaWeb.CadastroPessoas.Repositorio;

namespace TreinaWeb.CSharpAvancado.CadastroPessoas
{
    public partial class FrmPessoas : Form
    {
        public FrmPessoas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(PreencherDataGridView);
            thread.Start();
        }

        private void PreencherDataGridView()
        {
            Thread.Sleep(5000);
            IRepositorio<Pessoa> repositorioPessoa = new PessoaRepositorio();
            List<Pessoa> pessoas = repositorioPessoa.SelecionarTodos();
            dgvPessoas.Invoke((MethodInvoker)delegate { dgvPessoas.DataSource = pessoas; dgvPessoas.Refresh(); });
        }

        private void btnAdicionarPessoa_Click(object sender, EventArgs e)
        {
            FrmAdicionarPessoa frmAdicionarPessoa = new FrmAdicionarPessoa();
            frmAdicionarPessoa.ShowDialog();
            PreencherDataGridView();
        }
    }
}
