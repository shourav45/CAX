using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{

    public class RateInfo
    {
        [Key]
        public int RateInfoId { get; set; }
        public string PartyInfoId { get; set; }
        public string RateType { get; set; }
        public string FirstKP { get; set; }//for poly large
        public string FirstKPRate { get; set; }//for poly medium
        public string AfterFirstKPRate { get; set; }//for poly small
        public string AddBy { get; set; }
        public string AddDate { get; set; }
        public string Ex1 { get; set; }
        public string Ex2 { get; set; }
    }
}