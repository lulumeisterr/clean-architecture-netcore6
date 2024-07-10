using CrudInMemory.Domain;

namespace CrudInMemory.Application.Interfaces
{
    public interface IRemoveUser
    {
        public int Execute(string userName);
    }
}
