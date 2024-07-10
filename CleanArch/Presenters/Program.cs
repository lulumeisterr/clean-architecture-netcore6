using CrudInMemory.Application.Interfaces;
using CrudInMemory.Application;
using CrudInMemory.Domain;
using CrudInMemory.Infrastructure.Interfaces;
using CrudInMemory.Infrastructure.Repositorys;


// instâncias das dependências manualmente
IUserRepository userRepository = new InMemoryUserRepository();
IRegisterUser registerUser = new RegisterUserUseCase(userRepository);
IListUsers listUsers = new ListUsersUseCase(userRepository);
IFindUser findUser = new FindUserUseCase(userRepository);
IRemoveUser removeUser = new RemoveUserUseCase(userRepository);

bool exit = false;
while (!exit)
{
    Console.WriteLine("");
    Console.WriteLine("============= (1) - Cadastrar Usuario =============");
    Console.WriteLine("============= (2) - Listar todos usuarios =============");
    Console.WriteLine("============= (3) - Consultar Usuario Especifico =============");
    Console.WriteLine("============= (4) - Excluir Usuario Especifico =============");
    Console.WriteLine("============= (5) - Sair =============");
    Console.WriteLine("");
    int option = int.Parse(Console.ReadLine());
    switch (option)
    {
        case (int)Operacoes.ADICIONAR:
            Console.WriteLine("Digite o nome do usuário:");
            string userName = Console.ReadLine();
            registerUser.Execute(userName);
            Console.WriteLine("Usuário cadastrado.");
            break;
        case (int)Operacoes.PESQUISAR_TODOS:
            Console.WriteLine("########## Usuários cadastrados ##########");
            User[] users = listUsers.Execute();
            if (users?.Length > 0)
            {
                foreach (var user in users)
                    Console.WriteLine(user.Name);
                continue;
            }
            Console.WriteLine("Sem registros para ser exibido");
            break;
        case (int)Operacoes.PESQUISAR_POR_NOME:
            Console.WriteLine("Digite o nome do usuário:");
            string searchName = Console.ReadLine();
            (int result, int position) = findUser.Execute(searchName);
            if (result == 1)
            {
                Console.WriteLine($"Usuário {searchName} encontrado na posição {position}.");
                continue;
            }
            Console.WriteLine($"Usuário {searchName} não encontrado.");
            break;
        case (int)Operacoes.DELETAR:
            Console.WriteLine("Digite o nome do usuário:");
            string deleteName = Console.ReadLine();
            int deleteResult = removeUser.Execute(deleteName);
            if (deleteResult == 1)
            {
                Console.WriteLine($"Usuário {deleteName} excluído.");
                continue;
            }
            Console.WriteLine($"Usuário {deleteName} não encontrado.");
            break;
        case (int)Operacoes.SAIR:
            Console.WriteLine("Prorama encerrado");
            exit = true;
            break;
        default:
            Console.WriteLine("Opção invalida..");
            break;
    }
}
enum Operacoes
{
    ADICIONAR = 1,
    PESQUISAR_TODOS = 2,
    PESQUISAR_POR_NOME = 3,
    DELETAR = 4,
    SAIR = 5
}