
using Gamezone.ViewModels;

namespace Gamezone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); 
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateGameFormVM viewModel = new()
            {
                Categories = await _context.Categories
                                        .Select(c => new SelectListItem{Value = c.Id.ToString(),Text = c.Name})
                                        .OrderBy(c => c.Text)
                                        .ToListAsync()
            };

            return View(viewModel);
        }
    }
}
