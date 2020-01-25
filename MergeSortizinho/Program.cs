using System;

namespace MergeSortizinho
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[6]
            {
                3,
                5,
                2,
                8,
                15,
                10
            };

            MergeSort(numeros);

            foreach (var numero in numeros)
            {
                Console.WriteLine(numero);
            }

            Console.ReadKey();
        }

        public static void MergeSort(int[] numeros)
        {
            var quantidade = numeros.Length;
            var meio = quantidade / 2;

            if (quantidade > 1)
            {
                int[] parte1 = new int[meio];
                int[] parte2 = new int[quantidade - meio];
                int[] merge = new int[quantidade];

                Array.Copy(numeros, 0, parte1, 0, meio);
                Array.Copy(numeros, meio, parte2, 0, quantidade - meio);

                MergeSort(parte1);
                MergeSort(parte2);

                Intercala(quantidade, parte1, parte2, merge, numeros);
            }
        }

        private static void Intercala(int quantidade,  int[] parte1, int[] parte2, int[] merge, int[] numeros)
        {
            int ponteiroParte1 = 0;
            int ponteiroParte2 = 0;
            int ponteiroMerge = 0;

            while (ponteiroParte1 < parte1.Length && ponteiroParte2 < parte2.Length)
            {
                if (parte1[ponteiroParte1] < parte2[ponteiroParte2])
                {
                    merge[ponteiroMerge] = parte1[ponteiroParte1];
                    ponteiroMerge++;
                    ponteiroParte1++;
                }
                else
                {
                    merge[ponteiroMerge] = parte2[ponteiroParte2];
                    ponteiroMerge++;
                    ponteiroParte2++;
                }
            }

            ColocarElementosRestantesDaParte1(parte1, merge, ponteiroParte1, ponteiroMerge);
            ColocarElementosRestantesDaParte2(parte2, merge, ponteiroParte2, ponteiroMerge);
            DevolverElementosParaArrayOrigem(quantidade, merge, numeros);
        }

        private static void ColocarElementosRestantesDaParte2(int[] parte2, int[] merge,  int ponteiroParte2, int ponteiroMerge)
        {
            while (ponteiroParte2 < parte2.Length)
            {
                merge[ponteiroMerge] = parte2[ponteiroParte2];
                ponteiroParte2++;
                ponteiroMerge++;
            }
        }

        private static void ColocarElementosRestantesDaParte1(int[] parte1, int[] merge,  int ponteiroParte1,  int ponteiroMerge)
        {
            while (ponteiroParte1 < parte1.Length)
            {
                merge[ponteiroMerge] = parte1[ponteiroParte1];
                ponteiroParte1++;
                ponteiroMerge++;
            }
        }

        private static void DevolverElementosParaArrayOrigem(int quantidade, int[] merge, int[] numeros)
        {
            for (var i = 0; i < quantidade; i++)
            {
                numeros[i] = merge[i];
            }
        }
    }
}
