using Microsoft.EntityFrameworkCore;

namespace CSharpBelt.Models{
    public class MyContext : DbContext{
        public MyContext(DbContextOptions options) :base (options){}
        public DbSet<User> Users{get;set;}
        public DbSet<DojoActivity> Activities{get;set;}
        public DbSet<Plan> Plans{get;set;}

    }
}