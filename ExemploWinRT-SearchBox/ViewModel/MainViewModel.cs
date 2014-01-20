using GalaSoft.MvvmLight;
using System.Linq;

namespace ExemploWinRT_SearchBox.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public System.Collections.ObjectModel.ObservableCollection<Model.Produto> Produtos { get; private set; }
        public string[] NomesDeProdutosMaisPesquisados = { "pão", "leite" };

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Produtos = new System.Collections.ObjectModel.ObservableCollection<Model.Produto>();
            Produtos.Add(new Model.Produto() { ID = 1, Nome = "Pão" });
            Produtos.Add(new Model.Produto() { ID = 2, Nome = "Queijo" });
            Produtos.Add(new Model.Produto() { ID = 3, Nome = "Leite" });
            Produtos.Add(new Model.Produto() { ID = 4, Nome = "Açúcar" });
            Produtos.Add(new Model.Produto() { ID = 5, Nome = "Sal" });
            Produtos.Add(new Model.Produto() { ID = 6, Nome = "Pão de queijo" });
        }

        public System.Collections.Generic.IEnumerable<Model.Produto> Pesquisar(string pesquisa)
        {
            string pesquisaLowercase = pesquisa.ToLowerInvariant();
            return Produtos.Where(produto => produto.Nome.ToLowerInvariant().Contains(pesquisaLowercase));
        }
    }
}