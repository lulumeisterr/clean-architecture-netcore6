using CrudInMemory.Application.Interfaces;
using CrudInMemory.Application.UseCase;
using CrudInMemory.Domain;
using CrudInMemory.Infrastructure.Interfaces;
using CrudInMemory.Infrastructure.Repositorys;


// instâncias das dependências manualmente
IUserRepository userRepository = new InMemoryUserRepository();
IRegisterUser registerUser = new RegisterUser(userRepository);
IListUsers listUsers = new ListUsers(userRepository);
IFindUser findUser = new FindUser(userRepository);
IRemoveUser removeUser = new RemoveUser(userRepository);

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
            foreach (var user in users)
                Console.WriteLine(user.Name);
            break;
        case (int)Operacoes.PESQUISAR_POR_NOME:
            Console.WriteLine("Digite o nome do usuário:");
            string searchName = Console.ReadLine();
            (int result, int position) = findUser.Execute(searchName);
            if (result == 1)
                Console.WriteLine($"Usuário {searchName} encontrado na posição {position}.");
            else
                Console.WriteLine($"Usuário {searchName} não encontrado.");
            break;
        case (int)Operacoes.DELETAR:
            Console.WriteLine("Digite o nome do usuário:");
            string deleteName = Console.ReadLine();
            try
            {
                var (deleteResult, updatedUsers) = removeUser.Execute(deleteName);
                if (deleteResult == 1)
                    Console.WriteLine($"Usuário {deleteName} excluído.");
                else
                    Console.WriteLine($"Usuário {deleteName} não encontrado.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro ao excluir usuário: {ex.Message}");
            }
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