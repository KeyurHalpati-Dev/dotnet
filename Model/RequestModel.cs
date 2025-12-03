using System.ComponentModel.DataAnnotations;

namespace PMS.Model
{
    public class RAddEmp
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20,MinimumLength = 2,ErrorMessage = "Length is wrong")]
        public required string name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public required string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20,MinimumLength =8,ErrorMessage = "Length is wrong")]
        public required string pass { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public required string dept { get; set; }
        
    }

    public class RLoginEmp
    {
        [Required(ErrorMessage = "Email is required")]
        public required string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20,MinimumLength =8,ErrorMessage = "Length is wrong")]
        public required string pass {get; set; }
    }

    public class RUpsertProj
    {
        [Required(ErrorMessage = "id is required")]
        public required int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20,MinimumLength =2,ErrorMessage = "Length is wrong")]
        public required string name { get; set; }

        [Required(ErrorMessage = "detail is required")]
        [StringLength(200,MinimumLength =2,ErrorMessage = "Length is wrong")]
        public required string detail { get; set; }

        [Required(ErrorMessage = "lead id is required")]
        public required int LeadId { get; set; }

        [Required(ErrorMessage = "priorty is required")]
        [RegularExpression("^(Low|Medium|High)$", ErrorMessage = "It cant be that")]
        public required string Priority { get; set; }

        [Required(ErrorMessage = "dead line is required")]
        public required string deadline { get; set; }
    }

    public class RgetByPrio
    {
        [RegularExpression("^(Low|Medium|High)$", ErrorMessage = "It cant be that")]
        public  string? Priority { get; set; }
    }
}