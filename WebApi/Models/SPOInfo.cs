using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class SPOInfo
    {
        [Key]
        public int SPOInfoId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string Ex1 { get; set; }
        public string AddDate { get; set; }
        public string AddBy { get; set; }
    }
}