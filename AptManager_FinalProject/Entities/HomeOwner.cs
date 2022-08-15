using Models.MongoEntites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    /*
     * HomeOwner Entity Model for Home Information which is living In Home
     */
    public class HomeOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CarPlateId { get; set; }
        public decimal Bill { get; set; } = 0;
    }
}
