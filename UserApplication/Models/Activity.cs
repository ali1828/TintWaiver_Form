using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public string IPAdress { get; set; }
        public string Agent { get; set; }
        public DateTime Time { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser user { get; set; }
    }
}