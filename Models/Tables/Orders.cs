using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mvcshopping.Models.Tables
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        [StringLength(100)]
        public required string ProductName { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        public required int OrderQuantity { get; set; }
        [StringLength(200)]
        [Required]
        public int AddressId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

    }
}