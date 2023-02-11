using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace WalletService
{
    public class WalletService
    {
        public class Wallet
        {
            //данные кошелька
          [Key] public int Id { get; set; }
          public int ownerId { get; set; }
          public decimal balance { get; set; } 
          public string? createdAt { get; set; }
          public string? updatedAt { get; set; }

        }

        public class ApplicationContext: DbContext
        {
            public DbSet<Wallet> Wallets => Set<Wallet>();

            public ApplicationContext() => Database.EnsureCreated(); //Определяет есть ли бд если нет создает новую
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=WalletBasse.db");
                
            }
        }

        public void Walletnew(int ownerId, decimal balance, string createdAt, string updatedAt)
        {
            
            using (ApplicationContext db = new ApplicationContext())
            {
                Wallet wallet = new Wallet { ownerId = ownerId,balance = balance, createdAt = createdAt ,updatedAt = updatedAt};
                db.Wallets.Add(wallet);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");
            }

        }
    }
}
