namespace ConsultingRoom
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

        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonContract> PersonContract { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .Property(e => e.Email)
                .IsFixedLength();
        }
    }
}
