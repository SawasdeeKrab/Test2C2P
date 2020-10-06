namespace Test2C2P.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TwoC2PEntity : DbContext
    {
        public TwoC2PEntity()
            : base("name=TwoC2PEntity")
        {
        }

        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
