using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcshopping.Models.Tables
{
    public class Category
    {
        [Key]
        [Display(Name = "分類序號")]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "分類編號")]
        public string CategoryNo { get; set; }
        [Display(Name = "分類名稱")]
        [Required]
        [StringLength(50)]
        public required string CategoryName { get; set; }

    }
}