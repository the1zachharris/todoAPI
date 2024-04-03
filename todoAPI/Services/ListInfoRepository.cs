using Microsoft.EntityFrameworkCore;
using todoAPI.DbContexts;
using todoAPI.Entities;

namespace todoAPI.Services
{
    public class ListInfoRepository : IListInfoRepository
    {
        private ListInfoContext _context;

        public ListInfoRepository(ListInfoContext context)  
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List?> GetListAsync(int listId)
        {
            return await _context.Lists.Where(c =>  c.Id == listId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<List>> GetListsAsync()
        {
            return await _context.Lists.ToListAsync();
        }

        public async Task CreateListAsync(List list)
        {
            await _context.Lists.AddAsync(list);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
