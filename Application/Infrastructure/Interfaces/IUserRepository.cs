using CrudInMemory.Domain;

namespace CrudInMemory.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Adicionar usuario
        /// </summary>
        /// <param name="nome"></param>
        void Add(string nome);
        /// <summary>
        /// Listar usuarios
        /// </summary>
        /// <returns>Users</returns>
        User[] GetAll();
        /// <summary>
        /// Buscar usuario por nome
        /// </summary>
        /// <param name="name">Nome</param>
        /// <returns></returns>
        (int result, int position) FindByName(string name);
        /// <summary>
        /// Remover usuario por nome
        /// </summary>
        /// <param name="name">Nome</param>
        /// <returns></returns>
        (int result, User[] users) Remove(string name);
    }
}
