
using System.ComponentModel.DataAnnotations.Schema;

namespace NoPorn.Mvc.Models;
public class Girl
{
    public int Id { get; set; }
    public string NameCN { get; set; }
    /// <summary>
    /// 拼音
    /// </summary>
    public string NamePY { get; set; }
    public ICollection<Image> Images { get; set; } = new List<Image>();
    /// <summary>
    /// 被pick的次数
    /// </summary>
    [NotMapped]
    public int PickedTimes { get => this.Images.Sum(i => i.PickedTimes); }
}
