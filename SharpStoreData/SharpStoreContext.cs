using SharpStoreModels.Models;

namespace SharpStoreData
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SharpStoreContext : DbContext
    {
       
        public SharpStoreContext()
            : base("name=SharpStoreContext")
        {
        }

        public virtual DbSet<Knife> Knifes { get; set; }
        public virtual DbSet<Message> Messages  { get; set; }

    }

}