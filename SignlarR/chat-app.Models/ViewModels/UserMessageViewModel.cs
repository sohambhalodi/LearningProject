using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.Models.ViewModels
{
    public class UserMessageViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? SenderId { get; set; }
        public string? ReceiverId { get; set; }
        public int GroupId { get; set; }
        [Required]
        public string? Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsSender { get; set; }
    }
}
