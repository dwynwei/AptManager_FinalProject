using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Building
    {
        [Key]
        public int Id { get; set; }
        public bool IsSettled { get; set; }
        public string HomeType { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public int HomeOwnerId { get; set; }
        [ForeignKey("HomeOwnerId")]
        ICollection<User> User { get; set; }
    }
}
