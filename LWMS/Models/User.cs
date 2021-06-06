using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LWMS.Models
{
    [Serializable()]
    public class User
    {
        public User()
        {
            Group = new Group();
            KeepTrack = new KeepTrack();
        }
        public int ID { get; set; }
        public Group Group { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }
        public KeepTrack KeepTrack { get; set; }
    }
}