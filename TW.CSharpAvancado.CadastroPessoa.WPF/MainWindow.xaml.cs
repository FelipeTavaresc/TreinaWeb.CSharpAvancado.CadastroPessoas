using CadastroPessoas.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreinaWeb.CadastroPessoas.Repositorio;

namespace TW.CSharpAvancado.CadastroPessoa.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CarregarDataGrid()
        {
            IRepositorio<Pessoa> repositorioPessoa = new PessoaRepositorio();
            List<Pessoa> pessoas = repositorioPessoa.SelecionarTodos();
            dgrPessoas.ItemsSource = pessoas;

        }

        private void WdwMain_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarDataGrid();
        }

        private void BtnCadastrarPessoas_Click(object sender, RoutedEventArgs e)
        {
            WndCadastrarPessoa wndCadastrarPessoa = new WndCadastrarPessoa();
            wndCadastrarPessoa.ShowDialog();
            CarregarDataGrid();
        }
    }
}
