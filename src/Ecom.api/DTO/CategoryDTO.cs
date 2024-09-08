using System.ComponentModel.DataAnnotations;

namespace Ecom.api.DTO
{
    public class CategoryDTO
    {
        //names as in xml to easy map
        [Required]
        public string name {  get; set; }
        public string description { get; set; }
    }
}
