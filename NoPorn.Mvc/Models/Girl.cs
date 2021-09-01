
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoPorn.Mvc.Models;
public class Girl
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Girl 姓名不得长于50个字符")]
    public string Name { get; set; }
    public string? AvatarUrl { get; set; }
    public ICollection<Image> Images { get; set; } = new List<Image>();
    /// <summary>
    /// 被pick的次数
    /// </summary>
    [NotMapped]
    public int PickedTimes { get => this.Images.Sum(i => i.PickedTimes); }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime ModifiedAt { get; set; }
    [Required]
    public bool IsDeleted { get; set; }

}
