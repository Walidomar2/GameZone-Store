using Gamezone.Interfaces;

namespace Gamezone.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetSelectList()
        {
            return await _context.Categories
                                 .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                                 .OrderBy(c => c.Text)
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
