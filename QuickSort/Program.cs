using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numeros = new decimal[]
            {
                9,
                8.5m,
                10,
                3,
                6.7m,
                9.3m,
                4,
                5,
                7
            };

            QuickSort(numeros, 0, numeros.Length -1);
            ImprimirArray(numeros);

            Console.WriteLine($"Index of valor 3: {BinarySearch(numeros, 3, 0, numeros.Length)}");
            Console.WriteLine($"Index of valor 7: {BinarySearch(numeros, 7, 0, numeros.Length)}");
            Console.WriteLine($"Index of valor 10: {BinarySearch(numeros, 10, 0, numeros.Length )}");
            Console.WriteLine($"Index of valor 3.7: {BinarySearch(numeros, 3.7m, 0, numeros.Length)}");
            Console.WriteLine($"Index of valor 2.8: {BinarySearch(numeros, 2.8m, 0, numeros.Length)}");
            Console.WriteLine($"Index of valor 100: {BinarySearch(numeros, 100, 0, numeros.Length)}");


            String[] nomes = {
                                "Maria",
                                "Camila",
                                "Fernando",
                                "Jonas",
                                "Andressa",
                                "Paloma",
                                "Alberto",
                                "Junior",
                                "Enzo",
                                "Paulo"
                             };


            QuickSort(nomes, 0, nomes.Length - 1);
            ImprimirArray(nomes);

            Console.ReadKey();
        }

        private static void ImprimirArray(decimal[] numeros)
        {
            foreach (var numero in numeros)
            {
                Console.WriteLine(numero);
            }
        }

        private static void ImprimirArray(string[] textos)
        {
            foreach (var texto in textos)
            {
                Console.WriteLine(texto);
            }
        }

        private static void QuickSort(decimal[] array, int de, int ate)
        {
            var elementos = ate - de;

            if(elementos >  1)
            {
                int posicaoDoPivo = quebraNoPivo(array, de, ate);
                QuickSort(array, de, posicaoDoPivo - 1);
                QuickSort(array, posicaoDoPivo, ate);
            }
        }


        private static void QuickSort(string[] array, int de, int ate)
        {
            var elementos = ate - de;

            if (elementos > 1)
            {
                int posicaoDoPivo = quebraNoPivo(array, de, ate);
                QuickSort(array, de, posicaoDoPivo - 1);
                QuickSort(array, posicaoDoPivo, ate);
            }
        }


        private static int quebraNoPivo(string[] array, int de, int ate)
        {
            string pivo = array[ate];
            int menoresEncontrados = de;

            for (int i = de; i <= ate; i++)
            {
                if (array[i].CompareTo(pivo) < 0)
                {
                    troca(array, i, menoresEncontrados);
                    menoresEncontrados++;
                }
            }

            troca(array, ate, menoresEncontrados);
            return menoresEncontrados++;
        }

        private static int BinarySearch(decimal[] array, decimal busca, int de, int ate)
        { 
            Console.WriteLine($"Buscando {busca} entre os indices {de} até {ate}");

            if (de > ate || de >= array.Length)
                return -1;

            int meio = (de + ate) / 2;

            if(array[meio] == busca)
            {
                return meio;
            }

            if ( busca  < array[meio] ) 
            {
                return BinarySearch(array, busca, de, meio - 1);
            }

            return BinarySearch(array, busca, meio + 1, ate);
            
        }


        private static int quebraNoPivo(decimal[] array, int de, int ate)
        {
            Decimal pivo = array[ate];
            int menoresEncontrados = de;

            for(int i = de; i <= ate; i++)
            {
                if(array[i] < pivo)
                {
                    troca(array, i, menoresEncontrados);
                    menoresEncontrados++;
                }
            }

            troca(array, ate, menoresEncontrados);

            Console.WriteLine($"Menores encontrados: {menoresEncontrados}");
            return menoresEncontrados++;
        }

        private static void troca(decimal[] array, int de, int para)
        {
            var elementDe = array[de];
            var elemenetoPara = array[para];

            array[de] = elemenetoPara;
            array[para] = elementDe;
        }


        private static void troca(string[] array, int de, int para)
        {
            var elementDe = array[de];
            var elemenetoPara = array[para];

            array[de] = elemenetoPara;
            array[para] = elementDe;
        }
    }
}
