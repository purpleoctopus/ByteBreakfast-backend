using System.ComponentModel.DataAnnotations.Schema;

namespace CodeBreakfast.Data.Entities;

public class UserConfig
{
    public Guid Id { get; set; }
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public UserConfigKey Key { get; set; }
    public string Value { get; set; }
}