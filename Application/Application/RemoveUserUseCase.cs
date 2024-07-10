using CrudInMemory.Application.Interfaces;
using CrudInMemory.Domain;
using CrudInMemory.Infrastructure.Interfaces;

namespace CrudInMemory.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class RemoveUserUseCase : IRemoveUser
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor / Injeção de dependencia.
        /// </summary>
        /// <param name="userRepository"></param>
        public RemoveUserUseCase(IUserRepository userRepository)
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
