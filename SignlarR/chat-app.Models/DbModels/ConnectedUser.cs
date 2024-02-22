using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.Models.DbModels
{
    public class ConnectedUser
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        [Required]
        public string? UserId { get; set; }
        public IdentityUser User { get; set; }
        [Required]
        public string ConnectionId { get; set; }
        public DateTime ConnectedDate { get; set; } = DateTime.Now;
    }
}
