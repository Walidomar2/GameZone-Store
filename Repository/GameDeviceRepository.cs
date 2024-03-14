using Gamezone.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gamezone.Repository
{
    public class GameDeviceRepository : IGameDeviceRepository
    {
        private readonly ApplicationDbContext _context;
        public GameDeviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetSelectList()
        {
            return await _context.Devices
                                        .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                                        .OrderBy(d => d.Text)
                                        .AsNoTracking()
                                        .ToListAsync();
        }
    }
}
