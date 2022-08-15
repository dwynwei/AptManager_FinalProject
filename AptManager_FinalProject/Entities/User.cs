using Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /*
     * User Account Model for Auth to System
     */
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NationalityId { get; set; }
        public UserRole Role { get; set; }
        public UserPassword Password { get; set; }

    }
}