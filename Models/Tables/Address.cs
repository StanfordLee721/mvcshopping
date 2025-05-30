using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcshopping.Models.Tables
{
    public class Address
    {
        [Required]
        public int AddressId { get; set; }
        [Required]
        [StringLength(100)]
        public required string StreetAddress { get; set; }
        [StringLength(250)]
        public string? SortNo { get; set; }
        [Required]
        [StringLength(250)]
        public decimal? Latitude { get; set; }
        [Required]
        [StringLength(250)]
        public decimal? Longitude { get; set; }
        [Required]
        public int? zipcode { get; set; }
        public string? UserNo { get; set; }

        public string? CodeNo { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EngName { get; set; }

        public string? GenderCode { get; set; }

        public DateTime? Birthday { get; set; }

        public string? CompName { get; set; }

        public string? CompID { get; set; }

        public string? DeptName { get; set; }

        public string? TitleName { get; set; }

        public string? CompTel { get; set; }

        public string? ContactTel { get; set; }

        public string? ContactEmail { get; set; }

        public string? ContactAddress { get; set; }

        public string? LineID { get; set; }

        public string? FacebookID { get; set; }

        public string? TwitterID { get; set; }

        public string? InstagramID { get; set; }

        public string? LinkedInID { get; set; }

        public string? Remark { get; set; }
    }
}