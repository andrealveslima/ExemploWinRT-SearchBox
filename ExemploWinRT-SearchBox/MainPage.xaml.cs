using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ExemploWinRT_SearchBox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ViewModel.MainViewModel viewModel;

        public MainPage()
        {
            this.InitializeComponent();
            viewModel = (ViewModel.MainViewModel)this.DataContext;
        }

        private void SearchBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
        {
            IEnumerable<Model.Produto> produtosEncontrados = viewModel.Pesquisar(args.QueryText);
            Frame.Navigate(typeof(ResultadoPesquisaProduto), new object[] {args.QueryText, produtosEncontrados});
        }

        private void Searchbox_SuggestionsRequested(SearchBox sender, SearchBoxSuggestionsRequestedEventArgs args)
        {
            string queryTextLowercase = args.QueryText.ToLowerInvariant();

            foreach (string nomeDeProdutoMaisPesquisado in viewModel.NomesDeProdutosMaisPesquisados)
            {
                if ((string.IsNullOrWhiteSpace(queryTextLowercase)) ||
                    (nomeDeProdutoMaisPesquisado.ToLowerInvariant().StartsWith(queryTextLowercase)))
                {
                    args.Request.SearchSuggestionCollection.AppendQuerySuggestion(nomeDeProdutoMaisPesquisado);
                }
            }
        }
    }
}
