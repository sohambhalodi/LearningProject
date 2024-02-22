using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.Models.ViewModels
{
    public class ChatScreenViewModel
    {
        public string? SenderId { get; set; }
        public string? SenderName { get; set; }
        public string? ReceiverId { get; set; }
        public string? ReceiverName { get; set; }
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public IEnumerable<UserMessageViewModel> UserMessages { get; set; }
    }
}
