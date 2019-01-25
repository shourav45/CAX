using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class UserInfo
    {
        [Key]
        public int UserInfoId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Designation { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public string AddBy { get; set; }
        public string AddDate { get; set; }
        public string Ex1 { get; set; }
        public string Ex2 { get; set; }
    }
}