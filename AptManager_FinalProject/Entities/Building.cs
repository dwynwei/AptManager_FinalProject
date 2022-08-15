using Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /*
     * Home Entity Model for Home Information
     */
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsSettled { get; set; }
        public string HomeType { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public HomeOwner Owner { get; set; }
    }
}
