using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BLOG.Models
{
    public class POST
    {
        public int ID { get; set; }
        public DateTimeOffset CREATED { get; set; }
        public DateTimeOffset? UPDATED { get; set; }
        public string TITLE { get; set; }
        [AllowHtml]
        public string BODY { get; set;  }
        public byte[] MEDIA { get; set; }
        public bool PUBLISH { get; set; }

        //generic object - big pile of anything.
        //ie. ICollection = garbage bag, T= items in bag allowed
        public virtual ICollection<COMMENT> Comments { get; set; }
    }
    public class COMMENT
    {
        public int ID { get; set; }
        public int POSTID { get; set; }
        public DateTimeOffset CREATED { get; set; }
        public string BODY { get; set; }
        public string AUTHORID { get; set; }

        public virtual POST POST { get; set; }
        public virtual ApplicationUser AUTHOR { get; set; }
    }
}