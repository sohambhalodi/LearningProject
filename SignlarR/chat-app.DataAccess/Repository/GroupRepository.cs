using chat_app.DataAccess.Data;
using chat_app.DataAccess.IRepository;
using chat_app.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.DataAccess.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
