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

    // 商品上傳 ViewModel
    public class ProductUploadViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "商品名稱不能為空")]
        [Display(Name = "商品名稱")]
        public string Name { get; set; }

        [Display(Name = "商品描述")]
        public string Description { get; set; }

        [Required(ErrorMessage = "價格不能為空")]
        [Display(Name = "價格")]
        [Range(0, double.MaxValue, ErrorMessage = "價格必須大於0")]
        public decimal Price { get; set; }

        [Display(Name = "商品圖片")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "目前圖片")]
        public string CurrentImagePath { get; set; }
    }
}
