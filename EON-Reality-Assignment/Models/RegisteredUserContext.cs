using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EON_Reality_Assignment.Models
{
    public class RegisteredUserContext : DbContext
    {
        private string _connectionString;
        public RegisteredUserContext(DbContextOptions<RegisteredUserContext> options) : base(options)
        {
            
        }

        public RegisteredUserContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_connectionString != null)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<RegisteredUsers> tblRegisteredUsers { get; set; }
        public DbSet<UserSelectedDays> tblUserSelectedDays { get; set; }        
    }
}
