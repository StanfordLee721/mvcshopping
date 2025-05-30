using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcshopping.Models.Tables
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [StringLength(100)]
        [Display(Name = "商品編號")]
        public string ProductNo { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "商品名稱")]
        public required string ProductName { get; set; }
        [StringLength(250)]
        [Display(Name = "商品描述")]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "商品單價")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "庫存數量")]
        public required int StockQuantity { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "地址")]
        public string Address { get; set; }
        [StringLength(250)]
        public string? ImageUrl { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}