using CadastroPessoas.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            PreencherDataGridView();
        }

        private void PreencherDataGridView()
        {
            IRepositorio<Pessoa> repositorioPessoa = new PessoaRepositorio();
            List<Pessoa> pessoas = repositorioPessoa.SelecionarTodos();
            dgvPessoas.DataSource = pessoas;
            dgvPessoas.Refresh();
        }

        private void btnAdicionarPessoa_Click(object sender, EventArgs e)
        {
            FrmAdicionarPessoa frmAdicionarPessoa = new FrmAdicionarPessoa();
            frmAdicionarPessoa.ShowDialog();
            PreencherDataGridView();
        }
    }
}
