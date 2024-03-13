namespace Gamezone.Models
{
    public class Game : BaseEntity
    {
     
        [MaxLength(length: 2500)]
        public string Description { get; set; } = string.Empty;
        
        [MaxLength(length: 500)]
        public string Cover { get; set; } = string.Empty;
        
        public int CategoryId { get; set; }
        public Category Categories { get; set; } = default!;

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

    }
}
