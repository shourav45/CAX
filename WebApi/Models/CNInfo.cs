using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CNInfo
    {
        [Key]
        public int CNInfoId { get; set; }
        public string CNType { get; set; }
        public string DeliveryStatus { get; set; }
        public string Status { get; set; }
        public string PolySize { get; set; }
        public DateTime CNDate { get; set; }
        public string ServiceType { get; set; }
        public string PartyId { get; set; }
        public string Destination { get; set; }
        public string Follio { get; set; }
        public string ConsingeeName { get; set; }
        public string ConsigneeAddress { get; set; }
        public string ItemInfo { get; set; }
        public string Kgpiece { get; set; }
        public string RateType { get; set; }
        public string Weight { get; set; }
        public string ServiceCharge { get; set; }
        public string VatStatus { get; set; }
        public string VatPercent { get; set; }
        public string VatAmount { get; set; }
        public string AitStatus { get; set; }
        public string AitPercent { get; set; }
        public string AitAmount { get; set; }
        public string TotalAmount { get; set; }
        public string Ex1 { get; set; }
        public string Ex2 { get; set; }
        public string AddDate { get; set; }
        public string AddBy { get; set; }
        public string AddIp { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }
    }
}