public class Encounter{
    public int Id { get; set; }
    //E.g. virtual vs ambulant
    public string Class { get; set; }
    //E.g. annual checkup
    public string Type { get; set; }
    //Based on what referral request
    public ReferralRequest BasedOn { get; set; }
    public int ReferralRequestId { get; set; }

}