using Gamezone.Interfaces;
using Gamezone.ViewModels;

namespace Gamezone.Repository
{
    public class GamesRepository : IGamesRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagePath;
        public GamesRepository(ApplicationDbContext context,
                               IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagePath}";
        }

        public async Task Create(CreateGameFormVM gameModel)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(gameModel.Cover.FileName)}";
            var path = Path.Combine(_imagePath, coverName) ;

            using var stream = File.Create(path);
            await gameModel.Cover.CopyToAsync(stream);

            Game game = new()
            {
                Name = gameModel.Name,
                Description = gameModel.Description,
                CategoryId = gameModel.CategoryId,
                Cover = coverName,
                Devices = gameModel.SelectedDevices.Select(d => new GameDevice { DeviceID = d }).ToList()
            };

            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }
    }
}
