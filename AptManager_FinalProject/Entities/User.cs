using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CarPlateId { get; set; }

    }
}