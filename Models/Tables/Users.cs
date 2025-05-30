using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcshopping.Models.Tables
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public required string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public required string Password { get; set; }
        [Required]
        [StringLength(50)]
        public required string Email { get; set; }
        [StringLength(100)]
        public string? FullName { get; set; }
        [StringLength(200)]
        public string? Address { get; set; }
        [StringLength(20)]
        public string? Phone { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? LastLogin { get; set; }
    }

}