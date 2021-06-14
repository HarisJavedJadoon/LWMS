using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LWMS.Models
{
    [Serializable()]
    public class Vendor
    {
        public Vendor()
        {
            Group = new Group();
            KeepTrack = new KeepTrack();
        }
        public int ID { get; set; }
        public Group Group { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Landline { get; set; }
        public string MobileNo { get; set; }
        public string CNICNo { get; set; }
        public string SalesTaxNo { get; set; }
        public string NTNNo { get; set; }
        public string OfficeAddress { get; set; }
        public string LogoUrl { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public KeepTrack KeepTrack { get; set; }
    }
}