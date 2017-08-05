using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataAnalysis.Models
{
    public class DADbContext : DbContext
    {
        public DbSet<Stock> Stocks { get; set; }
    }
}