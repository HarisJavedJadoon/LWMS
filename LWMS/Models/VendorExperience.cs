using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LWMS.Models
{
    [Serializable()]
    public class VendorExperience
    {
        public VendorExperience()
        {
            KeepTrack = new KeepTrack();
            Vendor = new Vendor();
        }
        public int ID { get; set; }
        public Vendor Vendor { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string Description { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyContactNumber { get; set; }
        public string TenderAmount { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public KeepTrack KeepTrack { get; set; }


    }
}