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
    public class UserToGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("group")]
        public int GroupId { get; set; }
        public Group group { get; set; }

        [Required]
        [ForeignKey("Users")]
        public string? UserId { get; set; }
        public IdentityUser Users { get; set; }

    }
}
