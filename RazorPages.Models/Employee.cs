using System.ComponentModel.DataAnnotations;

namespace RazorPages.Models
{
   public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Имя не должно быть пустым.ВBедите имя!")]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email format")]
        [MaxLength(50), MinLength(2)]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Dept? Departament { get; set; }
    }
}
