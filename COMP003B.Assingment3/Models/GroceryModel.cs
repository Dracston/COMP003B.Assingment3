using System.ComponentModel.DataAnnotations;
namespace COMP003B.Assingment3.Models
{
    public class GroceryModel
    {
        [Required]
        public int PLU {  get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name="Product Name")]
        public string Name { get; set; }
        [Required]
        [Range(0,500)]
        public string Quantity {  get; set; }



    }
}
