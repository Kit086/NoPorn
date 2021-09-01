
using System.ComponentModel.DataAnnotations;

namespace NoPorn.Mvc.Models;
public class GirlCreateViewModel
{
    [Required(ErrorMessage ="请输入姓名"), MaxLength(50, ErrorMessage="姓名不得长于50个字符")]
    public string Name { get; set; }
    public IFormFile Avatar { get; set; }
}
