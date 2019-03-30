using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.ViewModels
{
    public class VMCNCargoManifest
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int CNInfoId { get; set; }
        public string Kgpiece { get; set; }
        public string CNType { get; set; }
        public string ConsingeeName { get; set; }
        public string Destination { get; set; }
    }
}