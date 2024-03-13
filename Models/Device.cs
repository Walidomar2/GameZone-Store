namespace Gamezone.Models
{
    public class Device : BaseEntity
    {
        [MaxLength(length:50)]
        public string Icon { get; set; } = string.Empty;
    }
}
