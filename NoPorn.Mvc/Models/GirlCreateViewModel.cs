
using System.ComponentModel.DataAnnotations;

namespace NoPorn.Mvc.Models;
public class GirlCreateViewModel
{
    [Required(ErrorMessage = "请输入姓名"), MaxLength(50, ErrorMessage = "姓名不得长于50个字符")]
    public string Name { get; set; }
    [Required(ErrorMessage = "请上传头像")]
    public IFormFile Avatar { get; set; }
}
