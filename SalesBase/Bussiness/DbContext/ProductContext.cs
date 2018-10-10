namespace Bussiness.DbContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=ProductContext")
        {
        }

        public virtual DbSet<bill_payment_in> bill_payment_in { get; set; }
        public virtual DbSet<bill_payment_out> bill_payment_out { get; set; }
        public virtual DbSet<catalog> catalogs { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<details_bill_payment_in> details_bill_payment_in { get; set; }
        public virtual DbSet<details_bill_payment_out> details_bill_payment_out { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<staff> staffs { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bill_payment_in>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<bill_payment_in>()
                .Property(e => e.update_user)
                .IsUnicode(false);

            modelBuilder.Entity<bill_payment_out>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<bill_payment_out>()
                .Property(e => e.update_user)
                .IsUnicode(false);

            modelBuilder.Entity<catalog>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<catalog>()
                .Property(e => e.update_user)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.company_cd)
                .IsFixedLength();

            modelBuilder.Entity<company>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.update_user)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.user_cd)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.update_user)
                .IsUnicode(false);

            modelBuilder.Entity<details_bill_payment_in>()
                .Property(e => e.price)
                .IsFixedLength();

            modelBuilder.Entity<details_bill_payment_in>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<details_bill_payment_in>()
                .Property(e => e.update_user)
                .IsUnicode(false);

            modelBuilder.Entity<details_bill_payment_out>()
                .Property(e => e.price)
                .IsFixedLength();

            modelBuilder.Entity<details_bill_payment_out>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<details_bill_payment_out>()
                .Property(e => e.update_user)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.update_user)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.user_cd)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<staff>()
                .Property(e => e.update_user)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_cd)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.create_user)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.update_user)
                .IsUnicode(false);
        }
    }
}
