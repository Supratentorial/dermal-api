public class ReferralRequest{
    public int Id { get; set; }
    public string Status { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public List<Media> Media { get; set; }

    
}