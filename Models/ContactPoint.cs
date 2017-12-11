using System.ComponentModel.DataAnnotations;

public class ContactPoint
{
    public int Id { get; set; }
    [Required]
    public string System { get; set; }
    [Required]
    public string Value { get; set; }
    public string Use { get; set; }
    public int Rank { get; set; }
}