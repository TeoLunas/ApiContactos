using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContactos.Infrastructure
{
    public partial class SCCSDbContext : DbContext
    {
        public SCCSDbContext()
        {

        }

        public SCCSDbContext(DbContextOptions<SCCSDbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
           

            base.OnModelCreating(modelBuilder);

        }

        partial void ModelCreatingPartial(ModelBuilder modelBuilder);


    }

}
