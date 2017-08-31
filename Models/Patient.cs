using System.Collections.Generic;

public class Patient
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public string Gender { get; set; }
    public List<Address> Addresses { get; set; }
    public HumanName Name { get; set; }
    public List<ContactPoint> Telecom { get; set; }
    public Practitioner GeneralPractitioner { get; set; }
}