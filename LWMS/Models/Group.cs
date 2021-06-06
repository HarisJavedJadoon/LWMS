using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LWMS.Models
{
    [Serializable()]
    public class Group
    {
        public Group()
        {
            KeepTrack = new KeepTrack();
        }
        public int ID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public KeepTrack KeepTrack { get; set; }
    }
}