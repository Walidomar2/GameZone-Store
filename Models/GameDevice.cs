namespace Gamezone.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public Game Games { get; set; } = default!;

        public int DeviceID { get; set; }
        public Device Device { get; set; } = default!;

    }
}
