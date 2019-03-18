using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class SubscriptionsAliasContext : DbContext
    {
        public SubscriptionsAliasContext(DbContextOptions<SubscriptionsAliasContext> options)
            : base(options)
        { }

        public DbSet<SubscriptionsAlias> SubscriptionsAlias { get; set; }
    }

    public class SubscriptionsAlias
    {
        public int Id { get; set; }
        public string SubscriptionId { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Username { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
