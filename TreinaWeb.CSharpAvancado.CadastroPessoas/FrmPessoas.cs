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
        private static readonly object locker = new object();

        public FrmPessoas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Thread thread = new Thread(PreencherDataGridView);
            //thread.Start();
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                IRepositorio<Pessoa> repositorioPessoa = new PessoaRepositorio();
                dgvPessoas.Invoke((MethodInvoker)delegate {
                    dgvPessoas.DataSource = repositorioPessoa.SelecionarTodos();
                    dgvPessoas.Refresh();
                });
            });
        }

        private void PreencherDataGridView()
        {
            Thread.Sleep(5000);
            Thread thread = new Thread(PreencherListaPessoas);
            Thread thread2 = new Thread(PreencherListaPessoas2);
            thread.Start();
            thread2.Start();
            thread.Join();
            thread2.Join();
            dgvPessoas.Invoke((MethodInvoker)delegate { dgvPessoas.DataSource = _pessoas; dgvPessoas.Refresh(); });
        }

        private void PreencherListaPessoas()
        {
            IRepositorio<Pessoa> repositorioPessoa = new PessoaRepositorio();
            List<Pessoa> pessoas = repositorioPessoa.SelecionarTodos();
            lock (locker)
            {
                foreach (Pessoa p in pessoas)
                {
                    p.Nome += " Thread 1";
                    _pessoas.Add(p);
                    Thread.Sleep(300);
                }
            }
        }

        private void PreencherListaPessoas2()
        {
            try
            {
                throw new Exception("Teste");
                IRepositorio<Pessoa> repositorioPessoa = new PessoaRepositorio();
                List<Pessoa> pessoas = repositorioPessoa.SelecionarTodos();
                lock (locker)
                {
                    foreach (Pessoa p in pessoas)
                    {
                        p.Nome += " Thread 2";
                        _pessoas.Add(p);
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                ExibirErro(ex);
            }

        }

        private void ExibirErro(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        private void btnAdicionarPessoa_Click(object sender, EventArgs e)
        {
            FrmAdicionarPessoa frmAdicionarPessoa = new FrmAdicionarPessoa();
            frmAdicionarPessoa.ShowDialog();
            //PreencherDataGridView();
        }
    }
}
