using chat_app.Models.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserMessage> UserMessages { get; set; }
        //public DbSet<ConnectedUser> ConnectedUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<UserToGroup> UsersToGroups { get; set; }
    }
}
