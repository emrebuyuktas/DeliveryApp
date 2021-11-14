using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Dtos
{
    public class UserListDto
    {
        //role
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name can not be null.")]
        [MaxLength(100, ErrorMessage = "Name can not be longer than 100 character.")]
        [MinLength(1, ErrorMessage = "Name can not be shorter than 1 character.")]
        public string Name { get; set; }

        [DisplayName("Surname")]
        [Required(ErrorMessage = "Surname can not be null.")]
        [MaxLength(100, ErrorMessage = "Surname can not be longer than 100 character.")]
        [MinLength(1, ErrorMessage = "Surname can not be shorter than 1 character.")]
        public string Surname { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "Role can not be null.")]
        [MaxLength(100, ErrorMessage = "Role can not be longer than 100 character.")]
        [MinLength(1, ErrorMessage = "Role can not be shorter than 1 character.")]
        public string Role { get; set; }

        [DisplayName("Telephone_number")]
        [Required(ErrorMessage = "Telephone_number can not be null.")]
        [MaxLength(15, ErrorMessage = "Telephone_number can not be longer than 15 character.")]
        [MinLength(10, ErrorMessage = "Telephone_number can not be shorter than 10 character.")]
        public string Telephone_number { get; set; }
    }
}
