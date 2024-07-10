using CrudInMemory.Domain;

namespace CrudInMemory.Application.Interfaces
{
    public interface IListUsers
    {
        public User[] Execute();
    }
}
