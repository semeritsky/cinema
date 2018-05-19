using Service.Repository.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class Context: DbContext
    {
        public Context() : base("cinema")
        {
           
        }

        public virtual DbSet<Place> Places { get; set; }
    }
}
