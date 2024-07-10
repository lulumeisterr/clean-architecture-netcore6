
//Criar uma  array
using Teste.ExtensionsMethod;

// Criar um menu
bool exit = false;
Console.WriteLine("Digite a quantidade de Cadastros a serem realizados");
string qtdCadastro = Console.ReadLine();
int qtOpcaoCadastro = Convert.ToInt32(qtdCadastro);
string[] nomes = new string[qtOpcaoCadastro];
Console.WriteLine("Selecione uma opção abaixo");
while (!exit) 
{
    Console.WriteLine("1 - Cadastrar Usuario");
    Console.WriteLine("2 - Consultar Usuario");
    Console.WriteLine("3 - Excluir Usuario");
    Console.WriteLine("4 - Sair Usuario");
    string input = Console.ReadLine();
    int opcao = Convert.ToInt32(input);
    switch (opcao)
    {
        case 1:
            CadastrarUsuario(nomes);
            Console.WriteLine("Usuário cadastrado..");
            while (true) 
            {
                Console.WriteLine("Deseja cadastrar mais ? Digite S ou N");
                int key = Console.Read();
                char continuarResposta = Convert.ToChar(key);
                if (continuarResposta.ToString().ToUpper() == "N") 
                    break;
                CadastrarUsuario(nomes);
                Console.WriteLine("Usuario cadastrado..");
            }
            Console.ReadLine();
            break;
        case 2:
            Console.WriteLine("########## Usuários cadastrados ##########");
            foreach (string nome in nomes)
              Console.WriteLine(nome);
            Console.WriteLine("########################################");
            break;
        case 3:
            Console.WriteLine("Digite o nome do Usuário");
            string excluirUsuarioPorNome = Console.ReadLine();
            for (int i = 0; i < nomes.Length; i++)
                if(!nomes[i].ToUpper().Equals(excluirUsuarioPorNome.ToUpper()))
                   nomes[i] = String.Empty;
            break;
        case 4:
            Console.WriteLine("Sair Usuário");
            exit = true;
            break;
        default:
            Console.WriteLine("Opção invalida..");
        break;
    }
}

static void CadastrarUsuario(string[] nomes)
{
    Console.WriteLine("Digite o seu nome");
    string input = Console.ReadLine();
    nomes.Add(Convert.ToString(input));
}

