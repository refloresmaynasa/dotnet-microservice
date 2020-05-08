namespace ProductService.Database.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
