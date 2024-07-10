using CrudInMemory.Application.Interfaces;
using CrudInMemory.Domain;
using CrudInMemory.Infrastructure.Interfaces;

namespace CrudInMemory.Application.UseCase
{
    /// <summary>
    /// 
    /// </summary>
    public class RemoveUser : IRemoveUser
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor / Injeção de dependencia.
        /// </summary>
        /// <param name="userRepository"></param>
        public RemoveUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public (int result, User[] users) Execute(string userName)
        {
            return _userRepository.Remove(userName);
        }
    }
}
