using CrudInMemory.Domain;

namespace CrudInMemory.Application.Interfaces
{
    public interface IRemoveUser
    {
        public (int result, User[] users) Execute(string userName);
    }
}
