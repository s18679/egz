using System.ComponentModel.DataAnnotations;

namespace egz.Models
{
    public class ModifyDoctor
    {
        [Required]
        public int Id { get; set; }
        public string IdDoctor { get; set; }

        [Email]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
