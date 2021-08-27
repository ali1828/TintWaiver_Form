using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UserApplication.Models
{
    public class Messages
    {
        public int Id { get; set; }

        public string From { get; set; }

        public string To { get; set; }
        public string MessageBody { get; set; }
        public DateTime SendTime { get; set; }
        [ForeignKey("From")]
        public virtual ApplicationUser Sender { get; set; }
        [ForeignKey("To")]
        public virtual ApplicationUser Receiver { get; set; }
        public bool Vu { get; set; }
    }
}