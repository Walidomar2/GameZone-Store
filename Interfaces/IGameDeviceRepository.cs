namespace Gamezone.Interfaces
{
    public interface IGameDeviceRepository
    {
        public Task<IEnumerable<SelectListItem>> GetSelectList();
    }
}
