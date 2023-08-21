using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FloristMary.Models
{
    public class Product
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Please enter a value")] //validation 
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a value")]
        [Column(TypeName = "decimal(8, 2)")] //validation
        public decimal Price { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; } // we create the foreign key relationship
        public string Image { get; set; }
        public string Slug { get; set; }

    }
}
