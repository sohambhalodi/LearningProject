using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using NuGet.Protocol.Plugins;
using chat_app.Models.DbModels;
using chat_app.Controllers;
using chat_app.DataAccess.IRepository;
using chat_app.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace chat_app.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private static Dictionary<string, string> _connectedUsers = new Dictionary<string, string>();
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        public ChatHub(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public override async Task OnConnectedAsync()
        {
            string userId = Context.UserIdentifier;
            var userWiseGroup = (from gm in _unitOfWork.Group.GetAll()
                          join users in _userManager.Users on userId equals users.Id
                          join utg in _unitOfWork.UserToGroup.GetAll() on gm.Id equals utg.GroupId
                          where utg.UserId == userId
                          select new
                          {
                              Id = gm.Id.ToString(),
                              Name = gm.Name
                          }).ToList();
            foreach (var group in userWiseGroup)
                await Groups.AddToGroupAsync(Context.ConnectionId, group.Name);
        }

        public async void UserDisconnected(string userId)
        {
            if (_connectedUsers.TryGetValue(userId, out string toUserConnectionId))
            {
                _connectedUsers.Remove(toUserConnectionId);
            }
        }

        public async Task SendMessageToUser(string toUserId, string message)
        {
            string fromUserId = Context.UserIdentifier;
            UserMessage userMessage = new UserMessage();
            userMessage.SenderId = fromUserId;
            userMessage.ReceiverId = toUserId;
            userMessage.Message = message;
            userMessage.CreatedDate = DateTime.Now;
            //ConnectedUser connectedUser = _unitOfWork.ConnectedUser.GetFirstOrDefault(x=>x.UserId== toUserId);
            //if (connectedUser!=null)
            //{
            await Clients.User(toUserId).SendAsync("ReceiveMessage", false,false, userMessage.ReceiverId, userMessage.SenderId, userMessage.Message, userMessage.CreatedDate);
            //}
            _unitOfWork.UserMesaage.Add(userMessage);
            _unitOfWork.Save();
            await Clients.Caller.SendAsync("ReceiveMessage", true,false, userMessage.SenderId, userMessage.ReceiverId, userMessage.Message, userMessage.CreatedDate);
        }

        public async void SendMessageToGroup(string groupId, string groupName, string message)
        {
            string senderId = Context.UserIdentifier;
            UserMessage userMessage = new UserMessage();
            userMessage.SenderId = senderId;
            userMessage.GroupId = Convert.ToInt32(groupId);
            userMessage.Message = message;
            userMessage.CreatedDate = DateTime.Now;
            await Clients.Group(groupName).SendAsync("ReceiveMessage", false, true, senderId, groupId, message, DateTime.Now);
            _unitOfWork.UserMesaage.Add(userMessage);
            _unitOfWork.Save();
            await Clients.Caller.SendAsync("ReceiveMessage", true,true,senderId, groupId, message, DateTime.Now);
        }

        //public override Task OnConnectedAsync()
        //{
        //    Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
        //    return base.OnConnectedAsync();
        //}

        //public override async Task OnDisconnectedAsync(Exception exception)
        //{
        //    _connectedUsers.Remove(Context.UserIdentifier);
        //    await base.OnDisconnectedAsync(exception);
        //}
    }
}
