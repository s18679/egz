using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace egz.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        [Email]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
