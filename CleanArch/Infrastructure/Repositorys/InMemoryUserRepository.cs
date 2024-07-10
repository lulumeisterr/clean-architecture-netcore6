using CrudInMemory.Infrastructure.ExtensionsMethod;
using CrudInMemory.Domain;
using CrudInMemory.Infrastructure.Interfaces;

namespace CrudInMemory.Infrastructure.Repositorys
{
    /// <summary>
    /// Repositorio em memoria
    /// </summary>
    public class InMemoryUserRepository : IUserRepository
    {
        private User[] _users = Array.Empty<User>();

        /// <summary>
        /// Adicionar usuarios usando array nativo
        /// </summary>
        /// <param name="user"></param>
        public void Add(string nome)
        {
            _users = _users.Add(nome);
        }
        
        /// <summary>
        /// Buscar usuarios por nome
        /// </summary>
        /// <param name="name">Nome</param>
        /// <returns></returns>
        public (int result, int position) FindByName(string name)
        {
            (int resultado, int posicao) = _users.FindByNameBinarySearch(name);
            if (resultado != 1)
                return (resultado, posicao);
            return (resultado, posicao);
        }

        /// <summary>
        /// Listar todos os nomes
        /// </summary>
        /// <returns></returns>
        public User[] GetAll() => _users.ToArray();

        /// <summary>
        /// Remover usuario por nome
        /// </summary>
        /// <param name="name">Nome</param>
        /// <returns></returns>
        public (int result, User[] users) Remove(string name)
        {
            (int resultado, int posicao) = _users.FindByNameBinarySearch(name);
            if (resultado != 1)
                return (0, _users.ToArray());
            _users.Remove(name);
            return (1, _users.ToArray());
        }
    }
}
