using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetCore_CRUD_MVC.Models
{
    public class UserModel
    {
        [Key,Required]
        public int Id { get; set; }        

        [DisplayName("First Name")]
        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "This Field is required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "This Field is required.")]
        public string LastName { get; set; }

        [DisplayName("Identity Number")]
        [Column(TypeName = "bigint")]
        [MaxLength(11,ErrorMessage = "Maximum 11 characters only.")]
        [MinLength(11, ErrorMessage = "Minimum 11 characters only.")]
        [Required(ErrorMessage = "This Field is required.")]
        public long IdentityNumber { get; set; }

        [DisplayName("Comment")]
        [Column(TypeName = "varchar(250)")]
        public string Comment { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime RegistrationTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime UpdateTime { get; set; }
    }
}
