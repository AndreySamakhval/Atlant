namespace Atlant.Dal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AtlantContext : DbContext
    {
        public AtlantContext()
            : base("name=AtlantDBContext")
        {
        }

        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Storekeeper> Storekeepers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
