using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_app.Models.ViewModels
{
    public class GroupViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(25)]
        [DisplayName("Group Name")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string status { get; set; }
    }
}
