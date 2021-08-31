
using Newtonsoft.Json;

namespace NoPorn.Mvc.Models;
public class Image
{
    public int Id { get; set; }
    public string Url { get; set; }
    public int GirlId { get; set; }
    [JsonIgnore]
    public Girl Girl { get; set; }
    /// <summary>
    /// 被选择的次数
    /// </summary>
    public int PickedTimes { get; set; }
}
