using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Core.Dtos
{
    public class ProductTypeUpdateDto
    {


        [DisplayName("Id")]
        [Required(ErrorMessage = "Id can not be null.")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name can not be null.")]
        [MaxLength(100, ErrorMessage = "Name can not be longer than 100 character.")]
        [MinLength(1, ErrorMessage = "Name can not be shorter than 1 character.")]
        public string Name { get; set; }
    }
}
