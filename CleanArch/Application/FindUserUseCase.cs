using CrudInMemory.Application.Interfaces;
using CrudInMemory.Infrastructure.Interfaces;
namespace CrudInMemory.Application
{
    public class FindUserUseCase : IFindUser
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Construtor / Injeção de dependencia.
        /// </summary>
        /// <param name="userRepository"></param>
        public FindUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public (int result, int position) Execute(string userName)
        {
            return _userRepository.FindByName(userName);
        }
    }
}
