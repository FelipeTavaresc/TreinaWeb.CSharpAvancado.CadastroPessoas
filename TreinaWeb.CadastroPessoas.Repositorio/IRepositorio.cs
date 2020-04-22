using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.CadastroPessoas.Repositorio
{
    public interface IRepositorio<TTipo>
    {
        List<TTipo> SelecionarTodos();
        int Adicionar(TTipo objeto);
    }
}
