using Microsoft.EntityFrameworkCore;
using PayBillAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayBillAPI.Entities
{
    public class BillContext:DbContext
    {
        public BillContext(DbContextOptions<BillContext> options) : base(options) { }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Payment;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        public DbSet<PhoneBill> PhoneBills { get; set; }
    }
}
