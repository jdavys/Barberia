namespace Barberia.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TextContext : DbContext
    {
        public TextContext()
            : base("name=TextContext1")
        {
        }

        public virtual DbSet<Registro> registro { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Registro>()
                .Property(e => e.precio);
        }
    }
}
