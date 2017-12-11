using System.ComponentModel.DataAnnotations;

public class HumanName
{
    public int Id { get; set; }
    public string Use { get; set; }
    public string Text { get; set; }
    [Required]
    public string Family { get; set; }
    [Required]
    public string Given { get; set; }
    public string Prefix { get; set; }
    public string Suffix { get; set; }
}