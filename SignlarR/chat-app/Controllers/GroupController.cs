using chat_app.DataAccess.IRepository;
using chat_app.Hubs;
using chat_app.Models.DbModels;
using chat_app.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace chat_app.Controllers
{
    public class GroupController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;
        public GroupController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, IHubContext<ChatHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _hubContext = hubContext;
        }
        
        public async Task<IActionResult> Index(int id=0)        
        {
            string userId = _userManager.GetUserId(User);
            if (id!=0)
            {
                UserToGroup userToGroup = new UserToGroup();
                userToGroup.GroupId = id;
                userToGroup.UserId = userId;
                Group group = _unitOfWork.Group.GetFirstOrDefault(x=>x.Id==id);
                var data = _unitOfWork.UserToGroup.GetFirstOrDefault(x=>x.UserId== userId && x.GroupId==id);
                if (data == null)
                {
                    _unitOfWork.UserToGroup.Add(userToGroup);
                    await _hubContext.Groups.AddToGroupAsync(userId, group.Name);
                    TempData["success"] = "You join the group";
                }
                else
                {
                    _unitOfWork.UserToGroup.Remove(data);
                    await _hubContext.Groups.RemoveFromGroupAsync(userId,group.Name);
                    TempData["success"] = "You left the group";
                }
                _unitOfWork.Save();
            }
            IEnumerable<GroupViewModel> groupViewModels = (from gm in _unitOfWork.Group.GetAll()
                        join users in _userManager.Users on userId equals users.Id
                        join utg in _unitOfWork.UserToGroup.GetAll().Where(x => x.UserId == userId).DefaultIfEmpty() on gm.Id equals utg?.GroupId into g
                        from utg in g.DefaultIfEmpty()
                        select new GroupViewModel
                        {
                            Id = gm.Id,
                            Name = gm.Name,
                            status = (utg == null ? "JOIN This Group" : "LEFT This Group")
                        }).ToList();
            return View(groupViewModels);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Group group)
        {
            if(!ModelState.IsValid)
            {
                return View(group); 
            }
            _unitOfWork.Group.Add(group);
            _unitOfWork.Save();
            TempData["success"] = "Group created successfully";
            ModelState.Clear();
            return RedirectToAction();
        }
    }
}
