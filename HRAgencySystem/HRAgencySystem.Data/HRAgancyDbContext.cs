using HRAgencySystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRAgencySystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HRAgancyDbContext : IdentityDbContext<User>
    {
        public HRAgancyDbContext()
            : base("HRAgancy", throwIfV1Schema: false)
        {
        }

        public static HRAgancyDbContext Create()
        {
            return new HRAgancyDbContext();
        }
    }
}