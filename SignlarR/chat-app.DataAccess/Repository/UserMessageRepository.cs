using chat_app.DataAccess.Data;
using chat_app.DataAccess.IRepository;
using chat_app.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.DataAccess.Repository
{
    public class UserMessageRepository : Repository<UserMessage>, IUserMessageRepository
    {
        public UserMessageRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
