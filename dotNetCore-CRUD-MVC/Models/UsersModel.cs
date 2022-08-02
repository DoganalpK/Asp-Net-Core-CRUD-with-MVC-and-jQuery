using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetCore_CRUD_MVC.Models
{
    public class UsersModel : TimeEntity
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Identification Number")]
        [Column(TypeName = "varchar(11)")]
        [MaxLength(11, ErrorMessage = "Maximum 11 characters only.")]
        [MinLength(11, ErrorMessage = "Minimum 11 characters only.")]
        [Required(ErrorMessage = "This Field is required.")]
        public string IdentityNumber { get; set; }

        [DisplayName("First Name")]
        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "This Field is required.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "This Field is required.")]
        public string LastName { get; set; }        

        [DisplayName("Comment")]
        [Column(TypeName = "varchar(250)")]
        public string? Comment { get; set; }

        [DisplayName("City")]
        [Column(TypeName = "int")]
        [Required(ErrorMessage = "This Field is required.")]
        public int CityId { get; set; }        
    }

    public class TimeEntity
    {
        [DisplayName("Create Time")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CreatedTime { get; set; }

        [DisplayName("Update Time")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime UpdatedTime { get; set; }
    }
}
