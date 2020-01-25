using System;

namespace AlgoritmosEstudo
{
    class Program
    {
        static void Main(string[] args)
        {
            // *** SelectionSort e InsertionSort ***

            var lamborghini = new Produto("Lamborghini", 1000000);
            var jipe = new Produto("Jipe", 46000);
            var brasilia = new Produto("Brasilia", 16000);
            var smart = new Produto("Smart", 46000);
            var fusca = new Produto("Fusca", 17000);

            Produto[] produtos = new Produto[]
            {
                lamborghini,
                jipe,
                brasilia,
                smart,
                fusca,
            };

            var menorProduto = BuscarMenor(produtos, 0, produtos.Length - 1);
            Console.WriteLine($"O menor produto é: {produtos[menorProduto].Descricao}, {produtos[menorProduto].Preco}");

            //SelectionSort(produtos);
            InsertionSort(produtos);

            Console.WriteLine("Produtos ordenados do maior para o menor: ");
            ImprimirProdutos(produtos);


         

            Console.ReadKey();
        }

        private static void ImprimirProdutos(Produto[] produtos)
        {
            foreach (var produto in produtos)
            {
                Console.WriteLine($"{produto.Descricao}, {produto.Preco}");
            }
        }

        private static Produto[] InsertionSort(Produto[] produtos)
        {
            // No InsertionSort eu vou analisando cada elemento da array com o seus anteriores,
            // enquanto o elemento da array for menor que o
            // seu anterior eu vou trocando eles de posição
            // até se for necessário chegar na primeira posição da array,
            // caso não tenha elementos menores
            // que ele, ele continua na mesma posição. On2

            for (var posicaoAtual = 1; posicaoAtual < produtos.Length; posicaoAtual++)
            {
                // Analiso posição por posição possui produtos menores.
                var analise = posicaoAtual;

                while (analise > 0 && produtos[analise].Preco < produtos[analise - 1].Preco)
                {
                    //Como meu produto é menor que o anterior eu vou trocar eles de posição
                    TrocarProdutosDePosicao(produtos, analise);

                    // Diminuo o numero da analise para continuar acompanhando o elemento
                    // que eu estou ordenando.
                    analise--;
                }
            }

            return produtos;
        }

        private static void TrocarProdutosDePosicao(Produto[] produtos, int analise)
        {
            var produtoAnalise = produtos[analise];
            var produtoAnteriorDaAnalise = produtos[analise - 1];

            produtos[analise] = produtoAnteriorDaAnalise;
            produtos[analise - 1] = produtoAnalise;
        }

        private static Produto[] SelectionSort(Produto[] produtos)
        {
            // o for percorre até a penultima casa, pq senão no ultimo laço seria inutil,
            // já que seria ordenação de um elemento; On2

            for(var posicaoAtual = 0; posicaoAtual < produtos.Length - 1; posicaoAtual++)
            {         
                var maisBarato = BuscarMenor(produtos, posicaoAtual, produtos.Length - 1);

                Produto produtoMaisBarato = produtos[maisBarato];
                produtos[maisBarato] = produtos[posicaoAtual];
                produtos[posicaoAtual] = produtoMaisBarato;
            }

            return produtos;
        }

        //On
        private static int BuscarMenor(Produto[] produtos, int posicaoInicial, int posicaoFinal)
        {
            int maisBarato = posicaoInicial;

            for(var atual = posicaoInicial + 1; atual <= posicaoFinal; atual++)
            {
               if(produtos[atual].Preco < produtos[maisBarato].Preco)
               {
                    maisBarato = atual;
               }
            }

            return maisBarato;
        }
    }

    public class Produto
    {
        public Produto(string descricao, decimal preco)
        {
            Descricao = descricao;
            Preco = preco;
        }

        public string Descricao { get; set; }
        public Decimal Preco { get; set; }
    }
}
