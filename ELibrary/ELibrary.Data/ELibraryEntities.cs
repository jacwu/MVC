using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using ELibrary.Model.Models;

namespace ELibrary.Data
{
    public class ELibraryEntities : DbContext
    {

        public ELibraryEntities() : base("ELibraryDBConnection")
        {
        }

        //public virtual void Commit()
        //{
        //    base.SaveChanges();
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Configurations.Add(new GadgetConfiguration());
        //    //modelBuilder.Configurations.Add(new CategoryConfiguration());
        //}

        public System.Data.Entity.DbSet<Book> Books { get; set; }
        public System.Data.Entity.DbSet<Order> Orders { get; set; }
        public System.Data.Entity.DbSet<Tag> Tags { get; set; }
    }
}
