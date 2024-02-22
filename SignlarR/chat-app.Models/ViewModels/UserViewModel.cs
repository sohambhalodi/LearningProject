using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.Models.ViewModels
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        public ChatType ChatType { get; set; }

    }

    public enum ChatType
    {
        User,
        Group
    }

}
