using CrudInMemory.Application.Interfaces;
using CrudInMemory.Domain;
using CrudInMemory.Infrastructure.Interfaces;

namespace CrudInMemory.Application.UseCase
{
    /// <summary>
    /// 
    /// </summary>
    public class ListUsers : IListUsers
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor / Injeção de dependencia.
        /// </summary>
        /// <param name="userRepository"></param>
        public ListUsers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public User[] Execute() => _userRepository.GetAll();
    }
}
