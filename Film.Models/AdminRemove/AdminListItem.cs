using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film.Models.AdminRemove
{
    public class AdminListItem
    {
        [Key]
        public int RemoveId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public Guid ProfileId { get; set; }
    }
}
