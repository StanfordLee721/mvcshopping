using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace mvcshopping.Models.MetaDataModel
{
    [ModelMetadataType(typeof(z_metaProducts))]
    public partial class Products
    {

    }
    public class z_metaProducts
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int ProductNo { get; set; }
        [Required]
        [StringLength(100)]
        public required string ProductName { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        public required int StockQuantity { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        // [StringLength(250)]
        // public string? ImageUrl { get; set; }
        // [Required]
        // public int CategoryId { get; set; }
        // public DateTime? RegistrationDate { get; set; }
    }
}
