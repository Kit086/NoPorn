
using System.ComponentModel.DataAnnotations;

namespace NoPorn.Mvc.Models;
public class ImageCreateViewModel
{
    [Required]
    public int GirlId { get; set; }
    [Required(ErrorMessage = "请选择图片")]
    public IList<IFormFile> Images { get; set; }
}
