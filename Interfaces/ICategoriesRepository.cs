namespace Gamezone.Interfaces
{
    public interface ICategoriesRepository
    {
        public Task<IEnumerable<SelectListItem>> GetSelectList();
    }
}
