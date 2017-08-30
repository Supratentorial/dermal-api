public class Media{
    public int Id { get; set; }
    public string Url { get; set; }
    public string Type { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public string Note { get; set; }
}