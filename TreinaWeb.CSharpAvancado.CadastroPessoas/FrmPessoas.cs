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
        private List<Pessoa> _pessoas = new List<Pessoa>();

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
            Thread thread = new Thread(PreencherListaPessoas);
            thread.Start();
            thread.Join();
            dgvPessoas.Invoke((MethodInvoker)delegate { dgvPessoas.DataSource = _pessoas; dgvPessoas.Refresh(); });
        }

        private void PreencherListaPessoas()
        {
            IRepositorio<Pessoa> repositorioPessoa = new PessoaRepositorio();
            _pessoas = repositorioPessoa.SelecionarTodos();
        }

        private void btnAdicionarPessoa_Click(object sender, EventArgs e)
        {
            FrmAdicionarPessoa frmAdicionarPessoa = new FrmAdicionarPessoa();
            frmAdicionarPessoa.ShowDialog();
            PreencherDataGridView();
        }
    }
}
