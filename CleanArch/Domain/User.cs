namespace CrudInMemory.Domain
{
    public class User
    {
        public string Name { get; set; }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome do usuário não pode ser vazio ou nulo.");
            if (name.Length < 3)
                throw new ArgumentException("O nome do usuário deve ter pelo menos 3 caracteres.");
            Name = name;
        }
    }
}
