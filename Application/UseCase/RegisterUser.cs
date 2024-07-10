using CrudInMemory.Application.Interfaces;
using CrudInMemory.Domain;
using CrudInMemory.Infrastructure.Interfaces;
namespace CrudInMemory.Application.UseCase
{
    /// <summary>
    /// Use case responsavel por cadastrar um nome de usuario
    /// </summary>
    public class RegisterUser : IRegisterUser
    {
        /// <summary>
        /// Ponte entre os casos de uso e recursos externos responsavel por levar/permitir
        /// que o usecase vai atras de alguma informação/interaja com algum recurso.
        /// </summary>
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// Construtor / Injeção de dependencia.
        /// </summary>
        /// <param name="userRepository"></param>
        public RegisterUser(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Adicionar usuario
        /// </summary>
        /// <param name="userName">Nome do usuario</param>
        public void Execute(string userName)
        {
            User user = new User(userName);
            _userRepository.Add(user.Name);
        }
    }
}
