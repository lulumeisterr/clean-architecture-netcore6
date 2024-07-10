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
        /// Deletar usuario por nome
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public int Execute(string userName)
        {
            (int result, User[] users) = _userRepository.Remove(userName);
            return result;
        }
    }
}
