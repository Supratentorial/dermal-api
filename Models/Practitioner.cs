using System.Collections.Generic;

public class Practitioner
{
    public int Id { get; set; }
    public HumanName Name { get; set; }
    public List<ContactPoint> Telecom { get; set; }
    public List<Address> Addresses { get; set; }
    public string Gender { get; set; }
}