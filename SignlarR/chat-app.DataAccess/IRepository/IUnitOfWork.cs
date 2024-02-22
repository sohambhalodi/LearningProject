using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.DataAccess.IRepository
{
    public interface IUnitOfWork
    {
        IUserMessageRepository UserMesaage { get; }
        IConnectedUserRepository ConnectedUser { get; }
        IGroupRepository Group { get; }
        IUserToGroup UserToGroup { get; }   
        void Save();
    }
}
