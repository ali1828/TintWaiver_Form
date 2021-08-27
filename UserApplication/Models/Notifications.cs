using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class Notifications
    {
        public int Id { get; set; }
        public string NotificationUser { get; set; }
        public DateTime Time { get; set; }
        public string NotificationMessage { get; set; }
        public string Type { get; set; }
        public bool Viewed { get; set; }
        [ForeignKey("NotificationUser")]
        public ApplicationUser user { get; set; }
    }
}