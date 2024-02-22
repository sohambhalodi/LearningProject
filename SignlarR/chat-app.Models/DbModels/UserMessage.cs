using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace chat_app.Models.DbModels
{
    public class UserMessage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("SenderUser")]
        public string? SenderId { get; set; }
        public virtual IdentityUser SenderUser { get; set; }
        [ForeignKey("ReceiverUser")]
        public string? ReceiverId { get; set; }
        public virtual IdentityUser ReceiverUser { get; set; }
        public int GroupId { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        [Required]
        public string? Message { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
