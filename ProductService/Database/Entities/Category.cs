namespace ProductService.Database.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Required]
        public int CategoryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
