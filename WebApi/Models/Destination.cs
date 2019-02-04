using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        [Required]
        public string District { get; set; }

        public string Area { get; set; }
        public string AddBy { get; set; }
        public string AddDate { get; set; }
        public string Status { get; set; }
        public string Ex1 { get; set; }

    }
}