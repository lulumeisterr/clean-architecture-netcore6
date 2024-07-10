using CrudInMemory.Application.Interfaces;
using CrudInMemory.Application;
using CrudInMemory.Infrastructure.Interfaces;
using CrudInMemory.Infrastructure.Repositorys;
using CrudInMemory.Infrastructure.ExtensionsMethod;
using CrudInMemory.Domain;

namespace TesteUnitario.Adicionar
{
    [TestClass]
    public class AdicionarNomesTest
    {
        [TestMethod]
        public void Deve_Adicionar_Nome_Usuario_Com_Sucesso()
        {
            //Given
            IUserRepository userRepository = new InMemoryUserRepository();
            IRegisterUser registerUser = new RegisterUserUseCase(userRepository);
            IListUsers listUsers = new ListUsersUseCase(userRepository);

            //When
            registerUser.Execute("Lucas");
            registerUser.Execute("Maria");
            User[] users = listUsers.Execute();

            //Then
            var busca = ArrayExtensions.FindByNameBinarySearch(users, "Maria");
            Assert.AreEqual(1, busca.resultado);  
        }

        [TestMethod]
        public void Nao_Deve_Adicionar_Nome_Usuario_Com_Error()
        {
            //Given
            IUserRepository userRepository = new InMemoryUserRepository();
            IRegisterUser registerUser = new RegisterUserUseCase(userRepository);
            IListUsers listUsers = new ListUsersUseCase(userRepository);

            //When
            var exception = Assert.ThrowsException<ArgumentException>(() => registerUser.Execute("Lu"));

            //Then
            Assert.AreEqual("O nome do usuário deve ter pelo menos 3 caracteres.", exception.Message);
        }
    }
}
