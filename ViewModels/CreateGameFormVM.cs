namespace Gamezone.ViewModels
{
    public class CreateGameFormVM
    {
        [MaxLength(length:250)]
        public string Name { get; set; } = string.Empty;


        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();


        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(length:2500)]
        public string Description { get; set; } = string.Empty;
        public IFormFile Cover { get; set; } = default!;
    }
}
