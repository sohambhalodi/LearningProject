using chat_app.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.DataAccess.IRepository
{
    public interface IUserMessageRepository : IRepository<UserMessage>
    {

    }
}
