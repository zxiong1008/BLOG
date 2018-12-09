using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BLOG.Helper
{
    public class RDSContext : DbContext
    {
        public RDSContext() : base(Helpers.GetRDSConnectionString())
        {
        }

        public static RDSContext Create()
        {
            return new RDSContext();
        }
    }
}