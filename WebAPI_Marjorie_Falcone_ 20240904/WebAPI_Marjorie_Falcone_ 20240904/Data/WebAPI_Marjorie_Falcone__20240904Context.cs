using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_Marjorie_Falcone__20240904.Model;

namespace WebAPI_Marjorie_Falcone__20240904.Data
{
    public class WebAPI_Marjorie_Falcone__20240904Context : DbContext
    {
        public WebAPI_Marjorie_Falcone__20240904Context (DbContextOptions<WebAPI_Marjorie_Falcone__20240904Context> options)
            : base(options)
        {
        }

        public DbSet<WebAPI_Marjorie_Falcone__20240904.Model.User> User { get; set; } = default!;

        public DbSet<WebAPI_Marjorie_Falcone__20240904.Model.Post>? Post { get; set; }

        public DbSet<WebAPI_Marjorie_Falcone__20240904.Model.Notification>? Notification { get; set; }

        public DbSet<WebAPI_Marjorie_Falcone__20240904.Model.Comment>? Comment { get; set; }

        public DbSet<WebAPI_Marjorie_Falcone__20240904.Model.Follower>? Follower { get; set; }
    }
}
