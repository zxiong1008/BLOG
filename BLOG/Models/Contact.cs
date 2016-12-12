using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BLOG.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string message { get; set; }

        public string phone { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}