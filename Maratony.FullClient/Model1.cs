namespace Maratony.UI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Biegaczs> Biegaczs { get; set; }
        public virtual DbSet<Zawodies> Zawodies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zawodies>()
                .HasMany(e => e.Biegaczs)
                .WithOptional(e => e.Zawodies)
                .HasForeignKey(e => e.Zawody_ID);
        }
    }
}
