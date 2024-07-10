using CrudInMemory.Domain;
namespace CrudInMemory.Infrastructure.ExtensionsMethod
{
    /// <summary>
    /// Aplicabilidade de metodos de extensão pensando em S - Single Responsability e Open and Close Principe
    /// </summary>
    public static class ArrayExtensions
    {
        private static readonly int NAO_ENCONTRADO_NA_LISTA = -1;
        private static readonly int ENCONTRADO_NA_LISTA = 1;
        private static readonly int SEM_POSICAO = -1;

        /// <summary>
        /// Adicionar elementos no array
        /// </summary>
        /// <param name="originalArray"></param>
        /// <param name="novoValor"></param>
        /// <returns>Array</returns>
        public static User[] Add(this User[] originalArray, string novoValor)
        {
            CheckArrayNull(originalArray);
            for (int i = 0; i < originalArray.Length; i++)
            {
                if (originalArray[i] == null)
                {
                    originalArray[i].Name = novoValor;
                    return originalArray;
                }
            }
            int newSize = originalArray.Length == 0 ? 1 : originalArray.Length + 1;
            Array.Resize(ref originalArray, newSize);
            originalArray[originalArray.Length - 1] = new User(novoValor);
            return originalArray;
        }
        /// <summary>
        /// Remover elementos do array e reajusta o array pos remocao do elemento
        /// </summary>
        /// <param name="originalArray">Aray</param>
        /// <param name="valorRemover">Valor</param>
        /// <param name="compactar">Reajustar tamanho do array</param>
        /// <returns>Array</returns>
        public static (int result, User[] array) Remove(this User[] originalArray, string valorRemover)
        {
            if (originalArray == null)
                throw new ArgumentNullException(nameof(originalArray));
            (int resultado, int posicao) = originalArray.FindByNameBinarySearch(valorRemover);
            if (resultado != ENCONTRADO_NA_LISTA)
                return (NAO_ENCONTRADO_NA_LISTA, originalArray);
            int n = originalArray.Length;
            int j = 0;
            originalArray[posicao] = null;
            for (int i = 0; i < n; i++)
                if (originalArray[i] != null)
                    originalArray[j++] = originalArray[i];
            Array.Resize(ref originalArray, j);
            return (ENCONTRADO_NA_LISTA, originalArray);
        }
        /// <summary>
        /// Encontra string no array de forma linear
        /// </summary>
        /// <param name="originalArray">Array</param>
        /// <param name="novoValor">Valor</param>
        /// <returns></returns>
        public static int FindByNameLinear(this User[] originalArray, string novoValor)
        {
            CheckArrayNull(originalArray);
            for (int i = 0; i < originalArray.Length; i++)
            {
                if (string.IsNullOrEmpty(originalArray[i].Name))
                    continue;
                if (originalArray[i].Name.ToUpper() == novoValor.ToUpper())
                    return ENCONTRADO_NA_LISTA;
            }
            return NAO_ENCONTRADO_NA_LISTA;
        }
        /// <summary>
        /// Busca Binaria responsavel por cortar a pesquisa
        /// pela metade e eliminar informacoes descenecessarias para buscar a informação de forma mais rapida
        /// partindo pelo meio da lista reduzindo drasticamente o número de comparações necessárias para encontrar um valor 
        /// em um array ordenado
        /// </summary>
        /// <param name="originalArray">Array</param>
        /// <param name="item">Valor a ser pesquisado</param>
        /// <returns>Int</returns>
        public static (int resultado, int posicao) FindByNameBinarySearch(this User[] originalArray, string item)
        {
            originalArray = originalArray.BubbleSort();
            int inicioArray = 0;
            int fimArray = originalArray.Length - 1;
            while (inicioArray <= fimArray)
            {
                int meio = (inicioArray + fimArray) / 2;
                string chute = originalArray[meio].Name.ToUpper();
                if (chute == item.ToUpper())
                    return (ENCONTRADO_NA_LISTA, meio);
                if (chute.CompareTo(item) < 0) // Se chute é menor que novoValor
                    inicioArray = meio + 1;
                else // Se chute é maior que novoValor
                    fimArray = meio - 1;
            }
            return (NAO_ENCONTRADO_NA_LISTA, SEM_POSICAO);
        }
        /// <summary>
        /// Ordenação utilizando a tecnica BubbleSort
        /// </summary>
        /// <param name="originalArray"></param>
        /// <param name="growing">Ordem crescente ou decrescente</param>
        /// <returns></returns>
        public static User[] BubbleSort(this User[] originalArray, bool growing = true)
        {
            User[] sortedArray = new User[originalArray.Length];
            Array.Copy(originalArray, sortedArray, originalArray.Length);
            // Verificar se é para ordenar crescente ou decrescente
            int direction = growing ? 1 : -1;
            for (int i = 0; i < sortedArray.Length - 1; i++)
                for (int j = 0; j < sortedArray.Length - 1 - i; j++)
                    if (string.Compare(sortedArray[j].Name, sortedArray[j + 1].Name) == direction)
                    {
                        string temp = sortedArray[j].Name;
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1].Name = temp;
                    }
            return sortedArray;
        }
        /// <summary>
        /// Checa array nullo
        /// </summary>
        /// <param name="originalArray">originalArray</param>
        private static void CheckArrayNull(User[] originalArray)
        {
            if (originalArray == null)
                throw new ArgumentNullException(nameof(originalArray));
        }
    }
}