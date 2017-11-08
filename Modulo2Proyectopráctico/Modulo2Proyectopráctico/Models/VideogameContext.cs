namespace Modulo2Proyectopráctico.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VideogameContext : DbContext
    {
        public VideogameContext()
            : base("name=VideogameContext")
        {
        }

        public virtual DbSet<Videogames> Videogames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
