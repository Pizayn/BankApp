using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DenemeApi.Entities.Concrete
{
   public class DenemeContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OKSGEAA;Database=BankApp;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TransactionOnAccount> TransactionOnAccounts { get; set; }

    }
}
