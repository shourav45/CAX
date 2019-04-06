using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models.ViewModels
{
    public class VMCNUserEntry
    {
       public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int CNNumber { get; set; }
    }
}