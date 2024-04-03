using todoAPI.Entities;

namespace todoAPI.Services
{
    public interface IListInfoRepository
    {
        Task<IEnumerable<List>> GetListsAsync();
        Task<List?> GetListAsync(int listId);

        Task CreateListAsync(List list);

        void DeleteList(List list);

        Task<bool> SaveChangesAsync();
    }
}
