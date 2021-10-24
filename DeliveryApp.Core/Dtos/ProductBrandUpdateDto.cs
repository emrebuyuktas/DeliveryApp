using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryApp.Core.Dtos
{
    public class ProductBrandUpdateDto
    {


        [DisplayName("Id")]
        [Required(ErrorMessage = "Id can not be null.")]
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage = "Name can not be null.")]
        [MaxLength(100, ErrorMessage = "Name can not be longer than 100 character.")]
        [MinLength(1, ErrorMessage = "Name can not be shorter than 1 character.")]
        public string Name { get; set; }
        

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is can not be null.")]
        [MinLength(10, ErrorMessage = "Description can not be shorter than 10 character.")]
        [MaxLength(500, ErrorMessage = "Description can not be longer than 500 character.")]
        public string Description { get; set; }       
        
        [DisplayName("Picture Url")]
        [Required(ErrorMessage = "PictureUrl can not be null.")]
        [MaxLength(250, ErrorMessage = "PictureUrl can not be longer than 250 character.")]
        [MinLength(5, ErrorMessage = "PictureUrl can not be shorter than 5 character.")]
        public string PictureUrl { get; set; }
    }
}
