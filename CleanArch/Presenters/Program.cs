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
        case (int)Operacoes.ADICIONAR: RegisterUser(registerUser); break;
        case (int)Operacoes.PESQUISAR_TODOS: ListUsers(); break;
        case (int)Operacoes.PESQUISAR_POR_NOME: FindUser(); break;
        case (int)Operacoes.DELETAR: RemoveUser(); break;
        case (int)Operacoes.SAIR: exit = true; break;
        default: Console.WriteLine("Opção invalida.."); break;
    }
}

void RegisterUser(IRegisterUser registerUser)
{
    Console.WriteLine("Digite o nome do usuário:");
    string userName = Console.ReadLine();
    registerUser.Execute(userName);
    Console.WriteLine("Usuário cadastrado.");
}
void ListUsers()
{
    Console.WriteLine("########## Usuários cadastrados ##########");
    User[] users = listUsers.Execute();
    if (!(users?.Length > 0))
    {
        Console.WriteLine("Sem registros para ser exibido");
        return;
    }
    foreach (User user in users)
        Console.WriteLine(user.Name);
}
void FindUser()
{
    Console.WriteLine("Digite o nome do usuário:");
    string searchName = Console.ReadLine();
    (int result, int position) = findUser.Execute(searchName);
    if (result == 1)
    {
        Console.WriteLine($"Usuário {searchName} encontrado na posição {position}.");
        return;
    }
    Console.WriteLine($"Usuário {searchName} não encontrado.");
}
void RemoveUser()
{
    Console.WriteLine("Digite o nome do usuário:");
    string deleteName = Console.ReadLine();
    int deleteResult = removeUser.Execute(deleteName);
    if (deleteResult == 1)
    {
        Console.WriteLine($"Usuário {deleteName} excluído.");
        return;
    }
    Console.WriteLine($"Usuário {deleteName} não encontrado.");
}
enum Operacoes
{
    ADICIONAR = 1,
    PESQUISAR_TODOS = 2,
    PESQUISAR_POR_NOME = 3,
    DELETAR = 4,
    SAIR = 5
}
