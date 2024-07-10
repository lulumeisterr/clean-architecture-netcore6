namespace CrudInMemory.Application.Interfaces
{
    public interface IFindUser
    {
        public (int result, int position) Execute(string userName);
    }
}
