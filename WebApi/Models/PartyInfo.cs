using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class PartyInfo
    {
        [Key]
        public int PartyInfoId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string SPOId { get; set; }
        public string AddDate { get; set; }
        public string Status { get; set; }
        public string AddBy { get; set; }

    }
}