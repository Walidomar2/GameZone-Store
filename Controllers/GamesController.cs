
using Gamezone.Interfaces;
using Gamezone.ViewModels;

namespace Gamezone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ICategoriesRepository _categoriesRepository;   
        private readonly IGameDeviceRepository _gameDeviceRepository;
        private readonly IGamesRepository _gamesRepository;
        public GamesController(ICategoriesRepository categoriesRepository,
                               IGameDeviceRepository gameDeviceRepository,
                               IGamesRepository gamesRepository)
        {
           
            _categoriesRepository = categoriesRepository;
            _gameDeviceRepository = gameDeviceRepository;
            _gamesRepository = gamesRepository;
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
                Categories = await _categoriesRepository.GetSelectList(),
                Devices = await _gameDeviceRepository.GetSelectList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormVM gameModel)
        {
            if (!ModelState.IsValid)
            {
                gameModel.Categories = await _categoriesRepository.GetSelectList();
                gameModel.Devices = await _gameDeviceRepository.GetSelectList();
                return View(gameModel);
            }

            await _gamesRepository.Create(gameModel);

            return RedirectToAction(nameof(Index));
        }
    }
}
