using chat_app.DataAccess.Data;
using chat_app.DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

		private protected ApplicationDbContext _context;
        public IUserMessageRepository UserMesaage { get; private set; }
        public IConnectedUserRepository ConnectedUser { get; private set; }
        public IGroupRepository Group { get; private set; }
        public IUserToGroup UserToGroup { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserMesaage = new UserMessageRepository(_context);
            ConnectedUser = new ConnectedUserRepository(_context);
            Group = new GroupRepository(_context);
            UserToGroup = new UserToGroupRepository(_context);
        }       

        void IUnitOfWork.Save()
        {
            _context.SaveChanges();
        }
    }
}
