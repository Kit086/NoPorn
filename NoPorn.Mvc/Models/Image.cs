
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace NoPorn.Mvc.Models;
public class Image
{
    public int Id { get; set; }
    [Required]
    public string Url { get; set; }
    [Required]
    public int GirlId { get; set; }
    /// <summary>
    /// 防止序列化时的循环引用，所以JsonIgnore掉
    /// </summary>
    [JsonIgnore]
    [Required]
    public Girl Girl { get; set; }
    /// <summary>
    /// 被选择的次数
    /// </summary>
    public int PickedTimes { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime ModifiedAt { get; set; }
    [Required]
    public bool IsDeleted { get; set; }
}
