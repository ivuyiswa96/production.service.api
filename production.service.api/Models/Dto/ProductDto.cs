using System.ComponentModel.DataAnnotations;

namespace production.service.api.Models.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
      
        [MinLength(2, ErrorMessage = "Please provide the name")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be numeric and greater than zero ")]
        public double Price { get; set; }
    }
}
