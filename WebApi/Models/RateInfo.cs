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
        [Required]
        public string RateType { get; set; }
        [Required]
        public string FirstKP { get; set; }//for poly large
        [Required]
        public string FirstKPRate { get; set; }//for poly medium
        [Required]
        public string AfterFirstKPRate { get; set; }//for poly small
        public string AddBy { get; set; }
        public string AddDate { get; set; }
        public string Ex1 { get; set; }//for doc this one doc type like big/general
        public string Ex2 { get; set; }
    }
}