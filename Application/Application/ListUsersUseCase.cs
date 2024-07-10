using CrudInMemory.Application.Interfaces;
using CrudInMemory.Domain;
using CrudInMemory.Infrastructure.Interfaces;

namespace CrudInMemory.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class ListUsersUseCase : IListUsers
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor / Injeção de dependencia.
        /// </summary>
        /// <param name="userRepository"></param>
        public ListUsersUseCase(IUserRepository userRepository)
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
