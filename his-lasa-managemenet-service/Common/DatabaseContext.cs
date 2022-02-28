using his_lasa_managemenet_service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace his_lasa_managemenet_service.Common
{
    public class DatabaseContext : DbContext
    {
        public DbContextOptions<DatabaseContext> options;
        public DbSet<Lasa> Lasa { set; get; }
        public DbSet<User> User { set; get; }
        public DatabaseContext() : base()
        { }

        public DatabaseContext(DbContextOptions<DatabaseContext> _options) : base(_options)
        {
            options = _options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //mapping variable ke setiap table yang ada di database
            builder.Entity<Lasa>().ToTable("TR_Lasa").HasKey(m => new { m.item_id });
            builder.Entity<User>().ToTable("MR_User").HasKey(m => new { m.user_id });
            

            base.OnModelCreating(builder);
        }
    }
}
