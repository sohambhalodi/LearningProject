using chat_app.DataAccess.IRepository;
using chat_app.Models.DbModels;
using chat_app.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Linq;

namespace chat_app.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly ISession _session;
        private readonly UserManager<IdentityUser> _userManager;
        public ChatController(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _session = httpContextAccessor.HttpContext.Session;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var query1 = (from users in _userManager.Users
                          where users.Id != userId
                          select new UserViewModel
                          {
                              Id = users.Id,
                              UserName = users.UserName,
                              ChatType = ChatType.User
                          }).ToList();

            var query2 = (from gm in _unitOfWork.Group.GetAll()
                          join users in _userManager.Users on userId equals users.Id
                          join utg in _unitOfWork.UserToGroup.GetAll() on gm.Id equals utg.GroupId
                          where utg.UserId == userId
                          select new UserViewModel
                          {
                              Id = gm.Id.ToString(),
                              UserName = gm.Name,
                              ChatType = ChatType.Group
                          }).ToList();

            List<UserViewModel> userVm = query1.Concat(query2).ToList();
            return View(userVm);
        }

        public async Task<IActionResult> Screen(string? receiverId, ChatType? Type)
        {
            string senderId = _userManager.GetUserId(User);
            var Sender = await _userManager.FindByIdAsync(senderId);
            var Receiver = await _userManager.FindByIdAsync(receiverId);
            var Group = _unitOfWork.Group.GetFirstOrDefault(x => x.Id == 1);
            if (Type == ChatType.Group)
                Group = _unitOfWork.Group.GetFirstOrDefault(x => x.Id == Convert.ToInt32(receiverId));
            List<string> UsersId = new List<string>() { senderId, receiverId };
            ChatScreenViewModel chatScreenVM = new ChatScreenViewModel();
            chatScreenVM.SenderId = Sender.Id;
            chatScreenVM.SenderName = Sender.UserName;
            chatScreenVM.ReceiverId = Type == ChatType.User ? Receiver.Id : "";
            chatScreenVM.ReceiverName = Type == ChatType.User ? Receiver.UserName : "";
            chatScreenVM.GroupId = Type == ChatType.Group ? Group.Id : 0;
            chatScreenVM.GroupName = Type == ChatType.Group ? Group.Name : "";
            chatScreenVM.UserMessages = from t in _unitOfWork.UserMesaage.GetAll()
                                        where Type == ChatType.User ? UsersId.Contains(t.SenderId) && UsersId.Contains(t.ReceiverId) : receiverId == t.GroupId.ToString()
                                        select new UserMessageViewModel
                                        {
                                            IsSender = t.SenderId == senderId ? true : false,
                                            Id = t.Id,
                                            SenderId = t.SenderId,
                                            ReceiverId = t.ReceiverId,
                                            GroupId = t.GroupId,
                                            Message = t.Message,
                                            CreatedDate = t.CreatedDate
                                        };
            return View(chatScreenVM);
        }

        public void AddUserMessage(UserMessage userMessage)
        {
            _unitOfWork.UserMesaage.Add(userMessage);
            _unitOfWork.Save();
        }
    }
}
