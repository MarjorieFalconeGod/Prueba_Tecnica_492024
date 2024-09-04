using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPP_Marjorie_Falcone_20240904.Models;

namespace WebAPP_Marjorie_Falcone_20240904.Data
{
    public class WebAPP_Marjorie_Falcone_20240904Context : DbContext
    {
        public WebAPP_Marjorie_Falcone_20240904Context (DbContextOptions<WebAPP_Marjorie_Falcone_20240904Context> options)
            : base(options)
        {
        }

        public DbSet<WebAPP_Marjorie_Falcone_20240904.Models.User> User { get; set; } = default!;

        public DbSet<WebAPP_Marjorie_Falcone_20240904.Models.Post>? Post { get; set; }

        public DbSet<WebAPP_Marjorie_Falcone_20240904.Models.Notification>? Notification { get; set; }

        public DbSet<WebAPP_Marjorie_Falcone_20240904.Models.Follower>? Follower { get; set; }

        public DbSet<WebAPP_Marjorie_Falcone_20240904.Models.Comment>? Comment { get; set; }
    }
}
